using ApplicationPropertiesSettings;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using ServiceKretaLogger;

namespace KretaRazorPages.Extensions
{
    public static class KretaRazorServiceExtensions
    {
        public static void ConfigureRazorPageServices(this IServiceCollection services)
        {
            services.AddLocalization(opt => opt.ResourcesPath = "Resources");
            services.AddMvc()
                .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();         
        }

        public static void ConfigureLocalization(this IServiceCollection services)
        {
            var supportedCultures = new[] { ApplicationProperties.GetDefaultCulture(), "en-US" };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                
                options.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                  new QueryStringRequestCultureProvider(),
                  new CookieRequestCultureProvider()
                };
            });         
        }

        // Loggolás
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureComponentsService(this IServiceCollection services)
        {            
        }
    }
}
