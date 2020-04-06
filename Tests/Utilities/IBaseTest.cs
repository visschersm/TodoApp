using Microsoft.Extensions.DependencyInjection;

namespace MTech.Tests.Utilities
{
    public interface IBaseTest
    {
        void RegisterDependencies(IServiceCollection services);
    }
}
