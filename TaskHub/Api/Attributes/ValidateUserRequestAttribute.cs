using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes
{
    public class ValidateUserRequestAttribute() : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments.TryGetValue("request", out object? value);
            if (value is null)
            {
                context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
                return;
            }
            Type? valType = value?.GetType();
            string? name = (string?)valType?.GetProperty("Name")?.GetValue(value);
            if (string.IsNullOrWhiteSpace(name))
            {
                context.Result = new BadRequestObjectResult("Имя пользователя не задано");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
