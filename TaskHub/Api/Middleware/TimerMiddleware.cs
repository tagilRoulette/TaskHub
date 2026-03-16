using System.Diagnostics;
using System.Net;

namespace Api.Middleware;

public class TimerMiddleware
{
    private RequestDelegate _next;
    private ILogger<TimerMiddleware> _logger;

    public TimerMiddleware(RequestDelegate next, ILogger<TimerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.GetEndpoint()?.Metadata.GetMetadata<TimerAttribute>() is not null)
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
        }
        await _next.Invoke(context);
        string headers = JoinHeaders(context.Response.Headers);
        _logger.LogInformation(headers);
    }

    private string JoinHeaders(IHeaderDictionary headers)
    {
        IEnumerable<string> headersLines = headers
            .Select(kvPair => $"{kvPair.Key}: {string.Join(", ", (IEnumerable<string>)kvPair.Value)}");
        return string.Join(";\n", headers);
    }
}

public static class TimerMiddlewareExtensions
{
    public static IApplicationBuilder UseTimer(this IApplicationBuilder app)
    {
        return app.UseMiddleware<TimerMiddleware>();
    }
}

public class TimerAttribute : Attribute;