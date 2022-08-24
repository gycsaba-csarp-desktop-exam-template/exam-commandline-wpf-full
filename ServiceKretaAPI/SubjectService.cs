using Newtonsoft.Json;
using System.Text;
using System.Net;
using KretaParancssoriAlkalmazas.Models.DataModel;
using ApplicationPropertiesSettings;
using KretaParancssoriAlkalmazas.Models.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;

namespace ServiceKretaAPI.Services
{
    public class SubjectService : ISubjectService
    {
        public async Task<List<Subject>>? GetSubjectsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                var respons = await client.GetAsync("/Subject/api/subject?orderBy=subjectName");

                var content = respons.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // Possible null reference return.
                return JsonConvert.DeserializeObject<List<Subject>>(content.Result);
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        public async Task<ListWithPaginationData<Subject>>? GetSubjectsAsyncWithPageData()
        {
            ListWithPaginationData<Subject> listWithPaginationData = new ListWithPaginationData<Subject>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                var respons = await client.GetAsync("/Subject/api/subject?orderBy=subjectName");

                var content = respons.Content.ReadAsStringAsync();
#pragma warning disable CS8603 // Possible null reference return.
                List<Subject> subjects = JsonConvert.DeserializeObject<List<Subject>>(content.Result);
#pragma warning restore CS8603 // Possible null reference return.
                
                listWithPaginationData.Items = subjects;
                listWithPaginationData.TotalPages= GetHeaderParameter(respons, "TotalPages");
                listWithPaginationData.TotalCount = GetHeaderParameter(respons, "TotalCount");
                listWithPaginationData.CurrentPage = GetHeaderParameter(respons, "CurrentPage");
                listWithPaginationData.PageSize = GetHeaderParameter(respons, "PageSize");
            }
            return listWithPaginationData;
        }




        public async Task<Subject>? GetSubjectByIdAsync(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                var respons = await client.GetAsync("Subject/api/subject/" + id.ToString());

                var content = respons.Content.ReadAsStringAsync();

#pragma warning disable CS8603 // Possible null reference return.
                return JsonConvert.DeserializeObject<Subject>(content.Result);
#pragma warning restore CS8603 // Possible null reference return.

            }
        }

        public async Task<long> GetNextSubjectIdAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                var result = await client.GetAsync("/Subject/api/subject?orderBy=subjectName");

                int id = GetHeaderParameter(result, "X-NextId");
                return id;
            }
        }

        public async Task<System.Net.HttpStatusCode> InsertNewSubjectAsync(Subject subject)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = GetHttpClientUri();

                String jsonString = JsonConvert.SerializeObject(subject);
                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/Subject/api/subject", httpContent);

                //string error = "" + response.Content + " : " + response.StatusCode;
                return response.StatusCode;
            }
        }

        public async Task<HttpStatusCode> UpdateSubjectAsync(long id, Subject subject)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = GetHttpClientUri();
                String jsonString = JsonConvert.SerializeObject(subject);
                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync("Subject/api/subject/" + id.ToString(), httpContent);

                return response.StatusCode;
            }
        }

        public async Task<HttpStatusCode> DeleteSubjectAsync(long id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = GetHttpClientUri();

                var response = await httpClient.DeleteAsync("Subject/api/subject/" + id.ToString());

                return response.StatusCode;
            }
        }

        private Uri GetHttpClientUri()
        {
            UriBuilder uri = new UriBuilder();
            uri = ApplicationProperties.GetAPIUri(uri);
            return uri.Uri;
        }

        private int GetHeaderParameter(HttpResponseMessage httpResponseMessage, string parameter)
        {

            if (httpResponseMessage.Headers.Contains(parameter))
            {
                var json = httpResponseMessage.Headers.GetValues(parameter).First();
                var nextId = JsonConvert.DeserializeObject<dynamic>(json);
                int id;
                if (nextId != null)
                {
                    if (int.TryParse(nextId["NextId"].ToString(), out id))
                        return id;
                }
            }
            return 0;
        }
    }
}


