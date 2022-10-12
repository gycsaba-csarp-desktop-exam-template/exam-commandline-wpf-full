using Newtonsoft.Json;
using System.Text;
using System.Net;

using ServiceKretaAPI.Lib;
using Microsoft.Extensions.Primitives;
using ApplicationPropertiesSettings;
using Microsoft.AspNetCore.Http;
using Kreta.Models.DataModel;
using Kreta.Models.Parameters;
using Kreta.Models.Helpers;

namespace ServiceKretaAPI.Services
{
    public class APISubjectService : IAPISubjectService
    {
        public async Task<List<Subject>>? GetSubjectsAsync(QueryStringParameters queryStringParameter)
        {
            if (queryStringParameter == null)
            {
                queryStringParameter = new QueryStringParameters();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                StringBuilder query = new StringBuilder("/Subject/api/subject");
                query.Append(queryStringParameter.ToQueryString);

                var respons = await client.GetAsync(query.ToString());

                var content = respons.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Subject>>(content.Result);

            }
        }

        public async Task<PagedList<Subject>>? GetSubjectsAsyncWithPageData(QueryStringParameters queryStringParameter)
        {
            if (queryStringParameter == null)
            {
                queryStringParameter = new QueryStringParameters();
            }

            PagedList<Subject> pagedSubjectList = new PagedList<Subject>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                StringBuilder query = new StringBuilder("/Subject/api/subject");
                query.Append(queryStringParameter.ToQueryString);
                
                var respons = await client.GetAsync(query.ToString());

                var content = respons.Content.ReadAsStringAsync();

                List<Subject> subjects = JsonConvert.DeserializeObject<List<Subject>>(content.Result);

                pagedSubjectList.Clear();
                ApiHeaderHandler apiHeaderHandler = new ApiHeaderHandler();
                if (subjects != null)
                {
                    pagedSubjectList.AddRange(subjects);
                    //TODO - a peged listbe benne vannak a paraméterek, a controller ezeket is adhatja...
                    pagedSubjectList.QueryString.NumberOfPage = apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "NumberOfPage");
                    pagedSubjectList.QueryString.CurrentPage = apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "CurrentPage");
                    pagedSubjectList.QueryString.PageSize = apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "PageSize");
                    pagedSubjectList.QueryString.NumberOfItem = apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "NumberOfItem");
                }
                else
                {
                    pagedSubjectList.QueryString.CurrentPage = apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "CurrentPage");
                    pagedSubjectList.QueryString.PageSize = apiHeaderHandler.GetHeaderParameter(respons, "X-Pagination", "PageSize");
                    pagedSubjectList.QueryString.NumberOfItem = 0;
                    pagedSubjectList.QueryString.NumberOfPage = 0;
                }
            }
            return pagedSubjectList;
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

        public async Task<bool> IsSubjectExsist(Subject subject)
        {
            using (var client=new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                var respons = await client.GetAsync("Subject/api/subject/" + subject.Id.ToString());

                if (respons.StatusCode == HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<long> GetNextSubjectIdAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                var result = await client.GetAsync("/Subject/api/subject?orderBy=subjectName");

                ApiHeaderHandler apiHeaderHandler = new ApiHeaderHandler();
                int id = apiHeaderHandler.GetHeaderParameter(result, "X-NextId","NextId");
                return id;
            }
        }

        public async Task<HttpStatusCode> Save(Subject subject)
        {
            bool isExsist = await IsSubjectExsist(subject);
            if (isExsist)
                return await UpdateSubjectAsync(subject.Id, subject);
            else
                return await InsertNewSubjectAsync(subject);
        }

        public async Task<HttpStatusCode> InsertNewSubjectAsync(Subject subject)
        {
            using (var httpClient = new HttpClient())
            {

                httpClient.BaseAddress = GetHttpClientUri();


                //SubjectForCreationDto subjectForCreation = new SubjectForCreationDto();  // clone
                //subjectForCreation.Clone(subject);

                String jsonString = JsonConvert.SerializeObject(subject);
                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/Subject/api/subject", httpContent);

                //string error = "" + response.Content + " : " + response.StatusCode;
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return HttpStatusCode.OK;
                else
                    return HttpStatusCode.InternalServerError;
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
            APIUriProperties apiUriProperties = new APIUriProperties();
            uri = apiUriProperties.GetAPIUri(uri);
            return uri.Uri;
        }
    }
}


