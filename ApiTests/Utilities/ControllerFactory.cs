using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MTech.TodoApp.ApiTests.Utilities
{
    public static class ControllerFactory
    {
        public static TController Create<TController>(object caller)
            where TController : ControllerBase
        {
            var services = new ServiceCollection();

            ((IBaseTest)caller).RegisterDependencies(services);

            services.AddScoped<TController>();

            var serviceProvider = services.BuildServiceProvider();
            var controller = serviceProvider.GetService<TController>();

            return controller;
        }
    }
}