using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceKretaLogger;
using System.Net;
using System.Runtime.InteropServices;

namespace KretaWebApi.ExceptionHandler
{
    // https://code-maze.com/global-error-handling-aspnetcore/
    // https://www.puresourcecode.com/dotnet/net6/handling-exceptions-globally-with-net6/

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerManager logger;
        private readonly bool isDev;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger, bool isDev)
        {
            this.next = next;
            this.logger = logger;
            this.isDev = isDev;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami hiba történt: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var contextFeature=httpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (contextFeature != null)
            {
                var error = contextFeature.Error;
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(
                    new ProblemDetails
                    {
                        Type = error.GetType().Name,
                        Status = (int)HttpStatusCode.InternalServerError,
                        Instance = contextFeature.Path,
                        Title = isDev ? $"{ex.Message}" : "An error occurred.",
                        Detail = isDev ? ex.StackTrace :null

                    }
                )); 
            }
        }
        /* public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger, bool isDev)
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
