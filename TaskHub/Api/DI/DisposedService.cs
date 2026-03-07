namespace Api.DI
{
    public class DisposedService : IDisposable, IHasInstanceId
    {
        public Guid InstanceId { get; }
        private readonly string _toString;
        
        public DisposedService(Guid instanceId)
        {
            InstanceId = instanceId;
            _toString = $"{GetType().FullName} {InstanceId}";
        }

        public void Log() => Console.WriteLine(ToString());

        public override string ToString()
        {
            return _toString;
        }

        public void Dispose()
        {
            Log();
            GC.SuppressFinalize(this);
        }
    }
}
