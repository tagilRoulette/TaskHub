using Api.DI;

namespace Api.Services
{
    public class TestTransient1 : DisposedService
    {
        public TestTransient1(ILogger<TestTransient1> logger) : base(logger) { }
    }
}
