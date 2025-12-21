using NetCoreWebApi.Server.Middlewares;

namespace NetCoreWebApi.Server.Extrensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        {
            // Registers RequestLoggingMiddleware into the HTTP pipeline
            return app.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
