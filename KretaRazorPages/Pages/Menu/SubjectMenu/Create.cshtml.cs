using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ServiceKretaAPI;
using ServiceKretaAPI.Services;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.DataModel;
using AutoMapper;

namespace KretaRazorPages.Pages.Menu.SubjectMenu
{
    public class CreateModel : PageModel
    {
        IMapper mapper;

        [BindProperty]
        public EFSubject Subject { get; set; }

        public CreateModel(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                IAPISubjectService subjectService = new APISubjectService();
                Subject subjectToCreate = mapper.Map<Subject>(Subject);
                var statusCode = await subjectService.InsertNewSubjectAsync(subjectToCreate);
                if (statusCode == System.Net.HttpStatusCode.NoContent)
                    TempData["success"] = "Subject created successfully";
                else
                    TempData["error"] = "Error: subject creation";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
