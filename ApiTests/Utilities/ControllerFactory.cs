using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MTech.TodoApp.ApiTests.Utilities
{
    public static class ControllerFactory
    {
        public static TController Create<TCaller, TController>(TCaller caller)
            where TCaller : IBaseTest
            where TController : ControllerBase
        {
            var services = new ServiceCollection();

            caller.RegisterDependencies(services);

            services.AddTransient<TController>();

            var serviceProvider = services.BuildServiceProvider();
            var controller = serviceProvider.GetService<TController>();

            return controller;
        }
    }
}