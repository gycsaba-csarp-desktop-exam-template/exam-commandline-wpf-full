using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaRazorPages.Services.Interface;
using KretaRazorPages.Services;

namespace KretaRazorPages.Pages.Menu.SubjectMenu
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Subject Subject { get; set; }
        
        [BindProperty]
        public long ? SubjectIdToModify { get; set; }

        private long _id;

        public void OnGet(long id)
        {
            SubjectIdToModify = id;
            ISubjectService subjectService = new SubjectService();
            Task<Subject> obj = subjectService.GetSubjectByIdAsync(id);
            if (obj!=null)
            {
                Subject = obj.Result;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (SubjectIdToModify!=Subject.Id)
            {
                ModelState.TryAddModelError("IdError", "Programming error");

            }
            if (ModelState.IsValid)
            {
                ISubjectService subjectService = new SubjectService();
                var statusCode = await subjectService.UpdateSubjectAsync(_id, Subject);
                return RedirectToPage("Subject");
            }
            return Page();
        }
    }
}
