namespace KretaRazorPages.ExceptionHandler
{
    public static class ExceptionMiddlwareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
