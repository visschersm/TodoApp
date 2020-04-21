using Microsoft.Extensions.DependencyInjection;
using Moq;
using MTech.Utilities.RequestHandler;

namespace MTech.Tests.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTestDependencies(this IServiceCollection services)
        {
            services.AddScoped(factory => Mock.Of<IHandler>());

            return services;
        }
    }
}
