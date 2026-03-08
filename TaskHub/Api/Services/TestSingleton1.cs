using Api.DI;

namespace Api.Services
{
    public class TestSingleton1 : DisposedService
    {
        public TestSingleton1(ILogger<TestSingleton1> logger) : base(logger) { }
    }
}
