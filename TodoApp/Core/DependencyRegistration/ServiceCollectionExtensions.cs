using Microsoft.Extensions.DependencyInjection;
using MTech.Utilities.RequestHandler;

namespace MTech.DependencyRegistration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IHandler, DefaultHandler>();

            return services;
        }
    }
}
