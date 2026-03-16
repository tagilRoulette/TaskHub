using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

//[AttributeUsage(AttributeTargets.Method)]
public class ResponseTimeHeaderAttribute : ActionFilterAttribute
{
    Stopwatch _timer = new();

    public override void OnActionExecuting(ActionExecutingContext context)
        => _timer.Start();

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        _timer.Stop();
        string timerMs = _timer.ElapsedMilliseconds.ToString();
        context.HttpContext.Response.Headers.Append("X-Response-Time-Ms", timerMs);
    }
}