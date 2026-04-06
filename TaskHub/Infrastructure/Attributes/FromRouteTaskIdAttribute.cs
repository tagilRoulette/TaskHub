using Infrastructure.Binders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Parameter)]
public class FromRouteTaskIdAttribute : ModelBinderAttribute, IBindingSourceMetadata
{
    public FromRouteTaskIdAttribute() : base(typeof(TaskIdBinder))
    {
        BindingSource = BindingSource.Path;
    }
}
