using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaRazorPages.Services.Interface;
using KretaRazorPages.Services;

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
            if (ModelState.IsValid)
            {
                ISubjectService subjectService = new SubjectService();
                var statusCode = await subjectService.InsertNewSubjectAsync(Subject);
                return RedirectToPage("Subject");
            }
            return Page();
        }
    }
}
