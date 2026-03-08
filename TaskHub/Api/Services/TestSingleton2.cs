using Api.DI;

namespace Api.Services
{
    public class TestSingleton2 : DisposedService
    {
        public TestSingleton2(ILogger<TestSingleton2> logger) : base(logger) { }
    }
}
