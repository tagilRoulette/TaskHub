using Api.DI;

namespace Api
{
    public static class IServiceProviderExtensions
    {
        /// <summary>
        /// Resolves first N services and logs them.
        /// </summary>
        /// <typeparam name="T">Generic type that needs to be resolved.</typeparam>
        /// <param name="n">Number of first matches to be resolved and displayed. Must be greater than zero.</param>
        /// <returns></returns>
        public static void ResolveFirst<T>(this IServiceProvider serviceProvider, int n)
            where T : IHasInstanceId
        {
            if (n <= 0) throw new ArgumentException($"'n' must be greater than zero. Got 'n' = {n}");
            Console.WriteLine("Type: " + typeof(T).FullName);
            var serviceIds = serviceProvider.GetServices<T>()
                .Take(n)
                .Select(service => service.InstanceId);
            Console.WriteLine("Instance IDs:");
            int idCounter = 1;
            Guid firstServiceId = serviceIds.First();
            foreach (var service in serviceIds)
                Console.WriteLine($"\t{idCounter++}) {service}");
            string negation = serviceIds.All(service => service == firstServiceId) ? "" : "not ";
            Console.WriteLine($"Instances are {negation}equal");
        }
    }
}
