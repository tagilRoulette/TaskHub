using Api.DI;

namespace Api.Services
{
    public class TestTransient2 : DisposedService
    {
        public TestTransient2(ILogger<TestTransient2> logger) : base(logger) { }
    }
}
