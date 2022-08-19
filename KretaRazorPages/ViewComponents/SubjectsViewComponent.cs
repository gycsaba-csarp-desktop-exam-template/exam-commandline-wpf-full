using Microsoft.AspNetCore.Mvc;
using ServiceKretaAPI;
using ServiceKretaAPI.Services;

namespace KretaRazorPages.ViewComponents
{
    public class SubjectsViewComponent : ViewComponent
    {
 
        public SubjectsViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ISubjectService subjectService = new SubjectService();
            var subject = await subjectService.GetSubjectsAsync();
            return View(subject);
        }
    }
}
