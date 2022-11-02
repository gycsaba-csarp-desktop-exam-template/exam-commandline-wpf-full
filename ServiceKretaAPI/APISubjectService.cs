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

                try
                {
                    var respons = await client.GetAsync(query.ToString());
                    var content = respons.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<Subject>>(content.Result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new APISubjectException(ex.Message);
                }
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

                try
                {
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new APISubjectException(ex.Message);
                }
            }        
            return pagedSubjectList;
        }


        public async Task<Subject>? GetSubjectByIdAsync(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                try
                {
                    var respons = await client.GetAsync("Subject/api/subject/" + id.ToString());
                    var content = respons.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<Subject>(content.Result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new APISubjectException(ex.Message);
                }
            }
        }

        public async Task<bool> IsSubjectExsist(Subject subject)
        {
            using (var client=new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();
                try
                {
                    var respons = await client.GetAsync("Subject/api/subject/" + subject.Id.ToString());
                    if (respons.StatusCode == HttpStatusCode.OK)
                        return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new APISubjectException(ex.Message);
                }
            }
            return false;
        }

        public async Task<long> GetNextSubjectIdAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = GetHttpClientUri();

                try
                {
                    var result = await client.GetAsync("/Subject/api/subject?orderBy=subjectName");

                    ApiHeaderHandler apiHeaderHandler = new ApiHeaderHandler();
                    int id = apiHeaderHandler.GetHeaderParameter(result, "X-NextId", "NextId");
                    return id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new APISubjectException(ex.Message);
                }
            }
        }

        public async Task<HttpStatusCode> Save(Subject subject)
        {
            bool isExsist;
            try
            {
                isExsist = await IsSubjectExsist(subject);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new APISubjectException(ex.Message);
            }
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

                try
                {
                    String jsonString = JsonConvert.SerializeObject(subject);
                    StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync("/Subject/api/subject", httpContent);

                    if (response.StatusCode == HttpStatusCode.Created)
                        return HttpStatusCode.OK;
                    else
                    {
                        
                        string error =response.Headers + " : " + response.Content + " : " + response.StatusCode ;
                        Console.WriteLine(error);
                        return HttpStatusCode.InternalServerError;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new APISubjectException(ex.Message);
                }
            }
        }

        public async Task<HttpStatusCode> UpdateSubjectAsync(long id, Subject subject)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = GetHttpClientUri();
                String jsonString = JsonConvert.SerializeObject(subject);
                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PutAsync("Subject/api/subject/" + id.ToString(), httpContent);
                    return response.StatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new APISubjectException(ex.Message);
                }
            }
        }

        public async Task<HttpStatusCode> DeleteSubjectAsync(long id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = GetHttpClientUri();

                try
                {
                    var response = await httpClient.DeleteAsync("Subject/api/subject/" + id.ToString());

                    return response.StatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new APISubjectException(ex.Message);
                }
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


