using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MTech.Tests.Utilities
{
    public class ControllerFactory
    {
        public ControllerFactory()
        {
            Services.AddTestDependencies();
        }

        public ServiceCollection Services { get; } = new ServiceCollection();

        public TController Create<TController>()
            where TController : ControllerBase
        {
            Services.AddScoped<TController>();

            var serviceProvider = Services.BuildServiceProvider();
            var controller = serviceProvider.GetService<TController>();

            return controller;
        }
    }
}