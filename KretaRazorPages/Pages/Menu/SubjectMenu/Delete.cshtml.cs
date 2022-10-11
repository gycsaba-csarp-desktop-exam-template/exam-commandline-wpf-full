using Kreta.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceKretaAPI;
using ServiceKretaAPI.Services;

namespace KretaRazorPages.Pages.Menu.SubjectMenu
{
    public class DeleteModel : PageModel
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
            IAPISubjectService subjectService = new APISubjectService();
            Task<Subject> obj = subjectService.GetSubjectByIdAsync(id);
            if (obj != null)
            {
                Subject = obj.Result;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (SubjectIdToModify != Subject.Id)
            {
                ModelState.TryAddModelError("IdError", "Programming error");

            }
            if (ModelState.IsValid)
            {
                IAPISubjectService subjectService = new APISubjectService();
                var statusCode = await subjectService.DeleteSubjectAsync(SubjectIdToModify);
                if (statusCode == System.Net.HttpStatusCode.NoContent)
                    TempData["success"] = "Subject created successfully";
                else
                    TempData["error"] = "Error: subject deletion";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
