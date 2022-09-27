using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using KretaParancssoriAlkalmazas.Models.DataModel;
using ServiceKretaAPI;
using ServiceKretaAPI.Services;
using KretaParancssoriAlkalmazas.Models.EFClass;
using AutoMapper;

namespace KretaRazorPages.Pages.Menu.SubjectMenu
{
    public class EditModel : PageModel
    {
        private long _subjectIdToModify;
        private IMapper _mapper;

        [BindProperty]
        public EFSubject Subject { get; set; }

        public EditModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        
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
            if (obj!=null)
            {
                Subject = _mapper.Map<EFSubject>(obj.Result);
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
                IAPISubjectService subjectService = new APISubjectService();
                Subject subjectToEdit = _mapper.Map<Subject>(Subject);
                var statusCode = await subjectService.UpdateSubjectAsync(_subjectIdToModify, subjectToEdit);
                if (statusCode == System.Net.HttpStatusCode.NoContent)
                    TempData["success"] = "Subject created successfully";
                else
                    TempData["error"] = "Error: subject modification";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
