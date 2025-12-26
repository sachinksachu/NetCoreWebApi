using System.Net;

namespace NetCoreWebApi.Server.Middlewares
{

    public class AuthenticationMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        //InvokeAsync is the entry point method of a custom middleware.
        //For each middleware, ASP.NET Core needs:
        //   A method to handle the request(InvokeAsync).
        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            string endpointPath = context.Request.Path;
            Console.WriteLine($"Authentication Middleware executing for endpoint: {endpointPath}");

            if(endpointPath.Equals("/api/todo", StringComparison.OrdinalIgnoreCase) &&
               context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
            {
                // Skip authentication for GET /api/todo
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("x-api-key", out var xApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API Key is missing");
                return;
            }

            if (!string.Equals(xApiKey, "x-123-key"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            //A method to call the next middleware.
            await _next(context);
        }
    }
}
