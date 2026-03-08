namespace Api.DI
{
    public class DisposedService : IDisposable, IHasInstanceId
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
        private readonly string _toString;
        
        public DisposedService()
        {
            _toString = $"{GetType().FullName} {InstanceId}";
            Console.WriteLine("Creating...");
            Log();
        }

        public void Log() => Console.WriteLine(ToString());

        public override string ToString()
        {
            return _toString;
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing...");
            Log();
            GC.SuppressFinalize(this);
        }
    }
}
