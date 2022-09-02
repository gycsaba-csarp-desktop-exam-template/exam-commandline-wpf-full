using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Pagination;
using KretaParancssoriAlkalmazas.Models.Parameters;
using Microsoft.AspNetCore.Mvc;
using ServiceKretaAPI;
using ServiceKretaAPI.Services;

namespace KretaRazorPages.ViewComponents
{
    public class SubjectsViewComponent : ViewComponent
    {
        private ListWithPaginationData<Subject> subjectListWithPaginationData;

        public SubjectsViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ISubjectService subjectService = new SubjectService();
            var subjectListWithPaginationData = await subjectService.GetSubjectsAsyncWithPageData(null);
            // TODO: ide rakjak-e vizsgálatot 
            if (subjectListWithPaginationData.Items == null)
                return View(new List<Subject>());
            else
                return View(subjectListWithPaginationData.Items);
        }
    }
}
