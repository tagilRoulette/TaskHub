using Api.Services;
using LoggingLibrary;

namespace Api;

/// <summary>
/// Точка входа приложения
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Запуск приложения
    /// </summary>
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .UseInfraSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();

        Console.WriteLine("Testing scope #1");
        using (var scope = host.Services.CreateScope()) {
            var services = scope.ServiceProvider;
            services.Resolve<TestTransient1>();
            services.Resolve<TestTransient2>();
            services.Resolve<TestScoped1>();
            services.Resolve<TestScoped2>();
            services.Resolve<TestSingleton1>();
            services.Resolve<TestSingleton2>();
        }
        Console.WriteLine("Testing scope #2");
        using (var scope = host.Services.CreateScope()) {
            var services = scope.ServiceProvider;
            services.Resolve<TestTransient1>();
            services.Resolve<TestTransient2>();
            services.Resolve<TestScoped1>();
            services.Resolve<TestScoped2>();
            services.Resolve<TestSingleton1>();
            services.Resolve<TestSingleton2>();
        }

        host.Dispose();
    }
}