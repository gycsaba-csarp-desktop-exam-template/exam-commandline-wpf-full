using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceKretaLogger;
using System.Net;

namespace KretaWebApi.ExceptionHandler
{
    public static class ExceptionMiddlwareExtensions
    {

        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        { 
            app.UseMiddleware<ExceptionMiddleware>();
        }

        /*public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger, bool isDev)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Valami hiba történt: {contextFeature.Error}");
                        var ex = contextFeature?.Error;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(
                            new ProblemDetails
                            {
                                Type = ex.GetType().Name,
                                Status = (int)HttpStatusCode.InternalServerError,
                                Instance = contextFeature?.Path,
                                Title = isDev ? $"{ex.Message}" : "An error occurred.",
                                Detail = isDev ? ex.StackTrace : null
                            }));
                    }
                });
            });
        }*/
    }
}
