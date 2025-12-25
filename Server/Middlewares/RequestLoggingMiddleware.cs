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
     * - It has the access to the HttpContext.
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
    public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<RequestLoggingMiddleware> _logger = logger;

        //InvokeAsync is the entry point method of a custom middleware.
        //For each middleware, ASP.NET Core needs:
        //   A method to handle the request(InvokeAsync).
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation(
                "Incoming Request: {Method} {Path}",
                context.Request.Method,
                context.Request.Path);

            //A method to call the next middleware.
            await _next(context);

            _logger.LogInformation(
                "Response Sent: {StatusCode}",
                context.Response.StatusCode);
        }
    }
}
