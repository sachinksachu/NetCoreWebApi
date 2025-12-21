namespace NetCoreWebApi.Server.Middlewares
{
    /*
     * RequestLoggingMiddleware
     * ------------------------
     * Purpose:
     * This middleware logs basic information about every incoming HTTP request
     * (HTTP method and request path).
     *
     * How it works:
     * - ASP.NET Core builds a middleware pipeline.
     * - Each middleware receives a RequestDelegate (_next) representing the next component in the pipeline.
     * - This middleware executes BEFORE the request reaches the controller.
     * - After logging, it calls _next(context) to pass control to the next middleware.
     *
     * Key points:
     * - Runs for every HTTP request.
     * - Does not modify the request or response.
     * - If _next(context) is NOT called, the request pipeline will stop here.
     *
     * Placement:
     * - Registered in Program.cs using app.UseRequestLogging().
     * - Should be placed AFTER global exception handling middleware.
     */
    public class RequestLoggingMiddleware(RequestDelegate requestDelegate, ILogger<RequestLoggingMiddleware> logger)
    {
        private readonly RequestDelegate _next = requestDelegate;
        private readonly ILogger<RequestLoggingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation(
                "Incoming Request: {Method} {Path}",
                context.Request.Method,
                context.Request.Path);

            await _next(context);

            _logger.LogInformation(
                "Response Sent: {StatusCode}",
                context.Response.StatusCode);
        }
    }
}
