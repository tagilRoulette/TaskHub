using Api.DI;

namespace Api.Services
{
    public class FancyClockService : DisposedService, IClockService
    {
        public FancyClockService() : base(Guid.NewGuid()) { }

        public string GetTime() => "Goodness gracious!" 
            + $"It's {DateTime.Now.ToShortTimeString()}." +
            "You are late for the tea ceremony.";

    }
}
