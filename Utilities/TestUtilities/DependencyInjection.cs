using Microsoft.Extensions.DependencyInjection;

namespace MTech.Tests.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTestDependencies(this IServiceCollection services)
        {
            var trol = new DefaultHandler();
            //services.AddScoped<IHandler>(factory => Mock.Of<IHandler>());
            return services;
        }
    }
}
