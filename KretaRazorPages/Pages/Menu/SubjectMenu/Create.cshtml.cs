using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using KretaParancssoriAlkalmazas.Models.DataModel;
using Newtonsoft.Json;
using System.Text;
using KretaRazorPages.Properties;
using KretaRazorPages.Static;

namespace KretaRazorPages.Pages.Menu.SubjectMenu
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Subject Subject { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            using (var httpClient=new HttpClient())
            {
                UriBuilder uri = new UriBuilder();
                uri = ApplicationProperties.GetAPIUri(uri);
                httpClient.BaseAddress = uri.Uri;

                String jsonString= JsonConvert.SerializeObject(Subject);
                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/Subject/api/subject", httpContent);

                string error = "" + response.Content + " : " + response.StatusCode;
            }
            return RedirectToPage("Subject");
        }
    }
}
