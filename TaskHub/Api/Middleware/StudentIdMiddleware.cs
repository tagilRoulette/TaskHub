using System.Net;

namespace Api.Middleware;

public class StudentIdMiddleware
{
    private RequestDelegate _next;

    public StudentIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Append("X-Student-Name", WebUtility.UrlEncode("Лукоянов Даниил Алексеевич"));
        context.Response.Headers.Append("X-Student-Group", WebUtility.UrlEncode("РИ-240948"));
        await _next.Invoke(context);
    }
}

public static class StudentIdMiddlewareExtensions
{
    public static IApplicationBuilder UseStudentId(this IApplicationBuilder app)
    {
        return app.UseMiddleware<StudentIdMiddleware>();
    }
}