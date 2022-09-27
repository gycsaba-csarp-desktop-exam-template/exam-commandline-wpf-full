using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace KretaWebApi.ExceptionHandler
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, bool isDev)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (contextFeature != null)
                    {
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
        }

    }
}
