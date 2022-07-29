using KretaWebApiContracts;
using KretaWEbApiLoggerService;

using Kreta.Models.Context;
using Microsoft.EntityFrameworkCore;
using Kreta.Repositories;
using Kreta.Repositories.Interfaces;
using KretaParancssoriAlkalmazas.Models.Helpers;
using KretaParancssoriAlkalmazas.Models.DataModel;


/*
AddTransient
Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services.

AddScoped
Scoped lifetime services are created once per request.

AddSingleton
Singleton lifetime services are created the first time they are requested (or when ConfigureServices is run if you specify an instance there) and then every subsequent request will use the same instance. 

 */

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

        // Loggolás
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        // MySql
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];

            services.AddDbContext<KretaContext>(o => o.UseMySql(connectionString,MySqlServerVersion.LatestSupportedServerVersion));
        }

        // Repository Wrapper
        public static void ConfigureWrapperRepository(this IServiceCollection services)
        {
            services.AddScoped<ISortHelper<SchoolClass>, SortHelper<SchoolClass>>();
            services.AddScoped<IRepositoryWrapper,RepositoryWrapper>();
        }
    }
}
