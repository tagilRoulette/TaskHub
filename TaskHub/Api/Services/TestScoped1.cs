using Api.DI;

namespace Api.Services
{
    public class TestScoped1 : DisposedService
    {
        public TestScoped1(ILogger<TestScoped1> logger) : base(logger) { }
    }
}
