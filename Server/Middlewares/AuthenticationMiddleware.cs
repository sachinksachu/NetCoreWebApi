using System.Net;
using NetCoreWebApi.Platform.Models.Attributes;

namespace NetCoreWebApi.Server.Middlewares
{

    public class AuthenticationMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            if (!await IsRequestAuthorized(context))
            {
                return; // stop pipeline
            }

            await _next(context); // exactly once
        }

        private async Task<bool> IsRequestAuthorized(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var requiresApiKey =
                endpoint?.Metadata.GetMetadata<RequireApiKeyAttribute>() != null;

            if (!requiresApiKey)
            {
                return true; // no auth required
            }

            if (!context.Request.Headers.TryGetValue("x-api-key", out var xApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API Key is missing");
                return false;
            }

            if (!string.Equals(xApiKey, "x-123-key"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid API Key");
                return false;
            }

            return true;
        }
    }

}
