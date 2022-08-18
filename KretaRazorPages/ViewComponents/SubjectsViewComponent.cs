using KretaRazorPages.Services;
using KretaRazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;

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
