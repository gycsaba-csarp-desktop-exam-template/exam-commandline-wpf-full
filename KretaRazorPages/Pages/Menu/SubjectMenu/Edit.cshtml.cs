using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaRazorPages.Services.Interface;
using KretaRazorPages.Services;

namespace KretaRazorPages.Pages.Menu.SubjectMenu
{
    public class EditModel : PageModel
    {
        private long _subjectIdToModify;

        [BindProperty]
        public Subject Subject { get; set; }
        
        [BindProperty]
        public long SubjectIdToModify 
        {
            get { return _subjectIdToModify; } 
            set { _subjectIdToModify = value; }
        }

        public void OnGet(long id)
        {
            _subjectIdToModify = id;
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
                var statusCode = await subjectService.UpdateSubjectAsync(_subjectIdToModify, Subject);
                return RedirectToPage("Subject");
            }
            return Page();
        }
    }
}
