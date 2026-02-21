using Karimaneh.WebApi.Middlewares;

namespace Karimaneh.WebApi.Extensions.ApplicationBuilder
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewares(
            this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseMiddleware<GlobalExceptionMiddleware>();

            return app;
        }
    }
}
