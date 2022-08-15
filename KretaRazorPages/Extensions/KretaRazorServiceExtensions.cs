using KretaRazorPages.Services;
using KretaRazorPages.Services.Interface;

namespace KretaRazorPages.Extensions
{
    public static class KretaRazorServiceExtensions
    {
        public static void ConfigureRazorPageServices(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<ISubjectService, SubjectService>();
        }
    }
}
