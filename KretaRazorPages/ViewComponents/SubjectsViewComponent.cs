using Kreta.Models.DataModel;
using Kreta.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using ServiceKretaAPI;
using ServiceKretaAPI.Services;

namespace KretaRazorPages.ViewComponents
{
    public class SubjectsViewComponent : ViewComponent
    {
        //private PagedList<Subject> subjectListWithPaginationData;

        public SubjectsViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IAPISubjectService subjectService = new APISubjectService();
            try
            {
                var pagedSubjectList = await subjectService.GetSubjectsAsyncWithPageData(null);

                if (pagedSubjectList == null)
                    return View(new List<Subject>());
                else
                    return View((List<Subject>)pagedSubjectList);
            }
            catch (Exception e)
            {
                return View(new List<Subject>());
            }
        }
    }
}
