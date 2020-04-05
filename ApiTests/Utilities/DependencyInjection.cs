using Microsoft.Extensions.DependencyInjection;

namespace MTech.TodoApp.ApiTests.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTestDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
