using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

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

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Method {Method}", context.HttpContext.Request.Method);
            _logger.LogInformation("Path: {Path}", context.HttpContext.Request.Path);
            _sw.Restart();

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _sw.Stop();
            _logger.LogInformation("Response status code: {Code}", context.HttpContext.Response.StatusCode);
            _logger.LogInformation("Action run time: {Time}", _sw.ElapsedMilliseconds);

            base.OnActionExecuted(context);
        }
    }
}
