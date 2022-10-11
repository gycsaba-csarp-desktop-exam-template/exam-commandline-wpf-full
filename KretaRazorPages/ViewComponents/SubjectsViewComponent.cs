using Kreta.Models.DataModel;
using Kreta.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using ServiceKretaAPI;
using ServiceKretaAPI.Services;

namespace KretaRazorPages.ViewComponents
{
    public class SubjectsViewComponent : ViewComponent
    {
        private PagedList<Subject> subjectListWithPaginationData;

        public SubjectsViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IAPISubjectService subjectService = new APISubjectService();
            var pagedSubjectList = await subjectService.GetSubjectsAsyncWithPageData(null);
            // TODO: ide rakjak-e vizsgálatot 
            if (pagedSubjectList == null)
                return View(new List<Subject>());
            else
                return View((List<Subject>) pagedSubjectList);
        }
    }
}
