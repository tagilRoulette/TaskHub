using Api.Attributes;

namespace Api.Filters;

public static class IServiceCollectionExtensions
{
    public static void AddFilters(this IServiceCollection services)
    {
        services.AddScoped<RequestLoggingFilterAttribute>();
        services.AddScoped<StudentInfoHeadersFilterAttribute>();
    }
}
