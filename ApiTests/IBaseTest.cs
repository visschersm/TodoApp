using Microsoft.Extensions.DependencyInjection;

namespace MTech.TodoApp.ApiTests
{
    public interface IBaseTest
    {
        void RegisterDependencies(IServiceCollection services);
    }
}
