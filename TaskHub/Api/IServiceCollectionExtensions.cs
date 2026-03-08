using Api.Services;

namespace Api
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddScopeTestServices(this IServiceCollection services)
        {
            services.AddSingleton<TestSingleton1>();
            services.AddSingleton<TestSingleton2>();
            services.AddScoped<TestScoped1>();
            services.AddScoped<TestScoped2>();
            services.AddTransient<TestTransient1>();
            services.AddTransient<TestTransient2>();
            return services;
        }
    }
}
