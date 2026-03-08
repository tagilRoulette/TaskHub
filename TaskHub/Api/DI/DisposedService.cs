namespace Api.DI
{
    public class DisposedService : IDisposable, IHasInstanceId
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
        private readonly string _logString;
        private readonly ILogger _logger;
        
        public DisposedService(ILogger logger)
        {
            _logString = $"{GetType().FullName} {InstanceId}";
            _logger = logger;
            _logger.LogInformation("Creating... " + _logString);
        }

        public void Dispose()
        {
            _logger.LogInformation("Disposing... " + _logString);
            GC.SuppressFinalize(this);
        }
    }
}
