using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Infrastructure.Binders;

public class TaskIdBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var modelName = bindingContext.ModelName;
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

        string value = valueProviderResult.FirstValue;
        if (string.IsNullOrWhiteSpace(value))
        {
            bindingContext.ModelState.TryAddModelError(modelName, "Идентификатор задачи не задан");
        }
        else if (Guid.TryParse(value, out Guid model))
        {
            bindingContext.Result = ModelBindingResult.Success(model);
        }
        else
        {
            bindingContext.ModelState.TryAddModelError(modelName, "Идентификатор задачи имеет некорректный формат");
        }
        return Task.CompletedTask;
    }
}
