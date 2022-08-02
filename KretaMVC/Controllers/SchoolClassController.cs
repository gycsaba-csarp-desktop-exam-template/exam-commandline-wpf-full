using Microsoft.AspNetCore.Mvc;

using Kreta.Repositories;
using Kreta.Repositories.Interfaces;
using KretaParancssoriAlkalmazas.Models.EFClass;


namespace KretaMVC.Controllers
{
    public class SchoolClassController : Controller
    {
        private IRepositoryWrapper wrapper;

        public SchoolClassController(IRepositoryWrapper wrapper)
        {
            this.wrapper = wrapper;
        }

        public IActionResult Index()
        {        
            return View();
        }

        public IActionResult Details()
        {
            return (View(wrapper.SchoolClass.GetSchoolClassById(1)));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSchoolClass(EFSchoolClass schoolClass)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(schoolClass);
        }
    }
}
