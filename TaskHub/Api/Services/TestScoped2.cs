using Api.DI;

namespace Api.Services
{
    public class TestScoped2 : DisposedService
    {
        public TestScoped2(ILogger<TestScoped2> logger) : base(logger) { }

    }
}
