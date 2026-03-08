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
        public static void Resolve<T>(this IServiceProvider serviceProvider)
            where T : IHasInstanceId
        {
            var first = serviceProvider.GetService<T>();
            var second = serviceProvider.GetService<T>();

            Console.WriteLine("Type: " + typeof(T).FullName);
            Console.WriteLine("Instance IDs:");
            Console.WriteLine($"\t1) {first.InstanceId}");
            Console.WriteLine($"\t2) {second.InstanceId}");
            string negation = first.InstanceId == second.InstanceId ? "" : "not ";
            Console.WriteLine($"Instances are {negation}equal");
        }
    }
}
