using System.Diagnostics;
using System.Net;

namespace Api.Middleware;

public class TimerMiddleware
{
    private RequestDelegate _next;

    public TimerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Stopwatch timer = Stopwatch.StartNew();
        context.Response.OnStarting(() =>
        {
            timer.Stop();
            string timerMs = timer.ElapsedMilliseconds.ToString();
            context.Response.Headers.Append("X-Response-Time-Ms", timerMs);

            foreach (var header in context.Response.Headers)
                Console.WriteLine(WebUtility.UrlDecode(header.ToString()));

            return Task.CompletedTask;
        });
        await _next.Invoke(context);
        Console.WriteLine(context.Response.Headers);
    }
}

public static class TimerMiddlewareExtensions
{
    public static IApplicationBuilder UseTimer(this IApplicationBuilder app)
    {
        return app.UseMiddleware<TimerMiddleware>();
    }
}