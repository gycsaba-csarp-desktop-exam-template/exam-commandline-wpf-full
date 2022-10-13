using Kreta.ExceptionHandler;
using Microsoft.AspNetCore.Http;
using ServiceKretaLogger;
using System.Diagnostics;
using System.Net;

namespace KretaRazorPages.ExceptionHandler
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerManager logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var sw = new Stopwatch();
            sw.Start();
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami hiba történt: {ex}");
                //HandleExceptionAsync(context, ex);
            }
            var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
            if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
            {
                logger.LogInfo($"{context.Request.Path} executed in {sw.ElapsedMilliseconds}ms");
            }
        }

        /*private void HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
           httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            var message = exception switch
            {
                AccessViolationException => "Access violation error",
                _ => "Internal server error",

            };

            await httpContext.Response.WriteAsync(
                new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = message,
                }.ToString()
           );
        }*/
    }
}
