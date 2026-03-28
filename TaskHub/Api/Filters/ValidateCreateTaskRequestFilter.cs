using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ValidateCreateTaskRequestFilter : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.HttpContext.Request.Body.Length == 0)
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
        if (context.)
            await next.Invoke();
    }
}
