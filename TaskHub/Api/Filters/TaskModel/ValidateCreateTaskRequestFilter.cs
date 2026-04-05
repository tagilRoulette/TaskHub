using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters.TaskModel;

public class ValidateCreateTaskRequestFilter : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.ActionArguments.TryGetValue("request", out object? request);
        if (request is null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }
        var taskType = request?.GetType();
        var taskTitle = (string?)taskType?
            .GetProperty("Title")?
            .GetValue(request);
        if (string.IsNullOrWhiteSpace(taskTitle))
        {
            context.Result = new BadRequestObjectResult("Название задачи не задано");
            return;
        }
        var userId = (Guid?)taskType?
            .GetProperty("CreatedByUserId")?
            .GetValue(request);
        if (userId is null || userId == Guid.Empty)
        {
            context.Result = new BadRequestObjectResult("Идентификатор пользователя не задан");
            return;
        }

        await base.OnActionExecutionAsync(context, next);
    }
}
