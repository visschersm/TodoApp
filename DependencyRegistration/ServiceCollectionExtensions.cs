using Microsoft.Extensions.DependencyInjection;
using MTech.RequestHandler;

namespace MTech.DependencyRegistration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IHandler, Handler>();

            return services;
        } 
    }
}
