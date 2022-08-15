using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaRazorPages.Services.Interface;
using Newtonsoft.Json;

namespace KretaRazorPages.Services
{
    public class SubjectService : ISubjectService
    {
        public async Task<List<Subject>> GetSubjectAsync()
        {
            using (var client = new HttpClient())
            {
                var endPoint = "https://kreta.azurewebsites.net/Subject/api/subject?orderBy=subjectName";
                var json = await client.GetStringAsync(endPoint);
                return JsonConvert.DeserializeObject<List<Subject>>(json);
            }
        }
    }
}
