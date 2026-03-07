using Api.DI;

namespace Api.Services
{
    public class ClockService : DisposedService, IClockService
    {
        public ClockService() : base(Guid.NewGuid()) { }

        public string GetTime() => DateTime.Now.ToShortTimeString();
    }
}
