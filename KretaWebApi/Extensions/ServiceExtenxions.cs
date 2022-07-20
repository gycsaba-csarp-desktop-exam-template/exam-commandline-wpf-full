using KretaWebApiContracts;
using KretaWEbApiLoggerService;

namespace KretaWebApi.Extensions
{
    public static class ServiceExtenxions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            // Cors-> külső erőforrások elérése
            services.AddCors(options =>
            {
                // Bármelyik címről, bármelyik metódus (Post,Get) és bármilyen fejlécel jön a HTTP kérés
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
        }

        // A windows webserver configuráció alapértelmezett
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
