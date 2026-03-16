using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

//[AttributeUsage(AttributeTargets.Method)]
public class StudentInfoHeadersAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var response = context.HttpContext.Response;

        if (!response.HasStarted)
        {
            response.Headers.Add("X-Student-Name", "Lukoyanov Daniil Alekseevich");
            response.Headers.Add("X-Student-Group", "RI-240948");
        }
    }
}
