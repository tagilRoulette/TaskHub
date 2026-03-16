using System.ComponentModel.DataAnnotations;

namespace Api.Attributes
{
    public class ValidateUserRequestAttribute() : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            Type? valType = value?.GetType();
            string? name = (string?)valType?.GetProperty("Name")?.GetValue(value);
            return string.IsNullOrWhiteSpace(name);
        }
    }
}
