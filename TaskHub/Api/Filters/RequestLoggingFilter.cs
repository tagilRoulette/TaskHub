using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Filters
{
    public class RequestLoggingFilterAttribute : ActionFilterAttribute
    {
        private readonly Stopwatch _sw = new();
        private readonly ILogger<RequestLoggingFilterAttribute> _logger;

        public RequestLoggingFilterAttribute(ILogger<RequestLoggingFilterAttribute> logger)
        {
            _logger = logger;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation("Method {Method}", context.HttpContext.Request.Method);
            _logger.LogInformation("Path: {Path}", context.HttpContext.Request.Path);
            _sw.Restart();

            await next.Invoke();

            _sw.Stop();
            var statusCodeResponse = ((IStatusCodeActionResult?)context.Result)?.StatusCode
                ?? context.HttpContext.Response.StatusCode;
            _logger.LogInformation("Response status code: {Code}", statusCodeResponse);
            _logger.LogInformation("Action run time: {Time}", _sw.ElapsedMilliseconds);
        }
    }
}
