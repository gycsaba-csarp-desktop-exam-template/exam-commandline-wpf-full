using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaRazorPages.Services.Interface;
using Newtonsoft.Json;

using KretaRazorPages.Properties;
using KretaRazorPages.Static;

namespace KretaRazorPages.Services
{
    public class SubjectService : ISubjectService
    {
        public async Task<List<Subject>> GetSubjectsAsync()
        {
            using (var client = new HttpClient())
            {
                UriBuilder uri = new UriBuilder();
                uri = ApplicationProperties.GetAPIUri(uri);
                client.BaseAddress = uri.Uri;
                //var json = await client.GetStringAsync("/Subject/api/subject?orderBy=subjectName");

                var respons = await client.GetAsync("/Subject/api/subject?orderBy=subjectName");

                var content = respons.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Subject>>(content.Result);
            }
        }

        public async Task<long> GetNextSubjectId()
        {
            using (var client = new HttpClient())
            {
                UriBuilder uri = new UriBuilder();
                uri = ApplicationProperties.GetAPIUri(uri);
                client.BaseAddress = uri.Uri;

                var result = await client.GetAsync("/Subject/api/subject?orderBy=subjectName");

                if (result.Headers.Contains("X-NextId"))
                {
                    var json = result.Headers.GetValues("X-NextId").First();
                    dynamic nextId = JsonConvert.DeserializeObject<dynamic>(json);
                    long id;
                    if (long.TryParse(nextId["NextId"].ToString(),out id))
                        return id;
                    else
                        return 0;
                }
                else
                    return 0;
            }
            return 0;
        }
    }
}
