using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MTech.Tests.Utilities
{
    public class ControllerFactory
    {
        public ControllerFactory()
        {
            Services = new ServiceCollection();
        }

        public ServiceCollection Services { get; }

        public TController Create<TController>()
            where TController : ControllerBase
        {
            Services.AddTestDependencies();

            Services.AddScoped<TController>();

            var serviceProvider = Services.BuildServiceProvider();
            var controller = serviceProvider.GetService<TController>();

            return controller;
        }
    }
}