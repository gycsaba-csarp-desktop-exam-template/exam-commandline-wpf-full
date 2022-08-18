using KretaRazorPages.Model;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KretaRazorPages.ViewComponents
{
    public class CultureSwitcherViewComponent : ViewComponent
    {
        private readonly IOptions<RequestLocalizationOptions> localizationOptions;

        public CultureSwitcherViewComponent(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            this.localizationOptions = localizationOptions;
        }

        public IViewComponentResult Invoke()
        {
            var cultureFeatures = HttpContext.Features.Get<IRequestCultureFeature>();
            var model = new CultureSwitcherModel()
            {
                CurrentUICulture = cultureFeatures.RequestCulture.UICulture,
                SupportedCultures = localizationOptions.Value.SupportedUICultures.ToList()

            };
            return View(model);
        }
    }
}
