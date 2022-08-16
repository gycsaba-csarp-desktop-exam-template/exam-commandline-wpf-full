using KretaRazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KretaRazorPages.ViewComponents
{
    public class SubjectsViewComponent : ViewComponent
    {
        private ISubjectService subjectService;

        public SubjectsViewComponent(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var subject = await subjectService.GetSubjectsAsync();
            return View(subject);
        }
    }
}
