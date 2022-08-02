using Kreta.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KretaRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public RepositoryWrapper repository;
        
        public IndexModel(RepositoryWrapper repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {

        }
    }
}