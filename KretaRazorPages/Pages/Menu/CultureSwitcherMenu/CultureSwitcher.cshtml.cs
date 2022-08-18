using KretaRazorPages.Model;
using KretaRazorPages.Static;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace KretaRazorPages.Pages.Menu.CultureSwitcher
{
    public class CultureSwitcher : PageModel
    {
        public CultureSwitcherModel cultureSwitcherModel { get; set; }

        public CultureSwitcher()
        {


        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            string selectedLanguage = Request.Form["culture"];
            if (selectedLanguage != null)
            {
                Thread.CurrentThread.CurrentCulture= CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
                AppSettingsControl.AddOrUpdateAppSettings("CurrentCulture", selectedLanguage);
            }
        }
    }
}
