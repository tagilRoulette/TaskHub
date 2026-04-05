using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters.TaskModel;

public class ValidateSetTaskTitleRequestFilter : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.ActionArguments.TryGetValue("request", out object? request);
        if (request is null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        await base.OnActionExecutionAsync(context, next);
    }
}
