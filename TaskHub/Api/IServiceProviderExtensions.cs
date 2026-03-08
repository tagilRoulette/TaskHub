using Api.DI;

namespace Api
{
    public static class IServiceProviderExtensions
    {
        public static void Resolve<T>(this IServiceProvider serviceProvider)
            where T : IHasInstanceId
        {
            var first = serviceProvider.GetService<T>();
            var second = serviceProvider.GetService<T>();
            var logger = serviceProvider.GetService<ILogger<Program>>();

            logger.LogInformation("Type: {type}", typeof(T).FullName);
            logger.LogInformation("Instance IDs:");
            logger.LogInformation("\t1) {id}", first.InstanceId);
            logger.LogInformation("\t2) {id}", second.InstanceId);
            string negation = first.InstanceId == second.InstanceId ? "" : "not ";
            logger.LogInformation("Instances are {negation}equal", negation);
        }
    }
}
