using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MTech.RequestHandler;
using MTech.TodoApp.Api;

namespace MTech.ApiTests.Utilities
{
    public static class ControllerFactory
    {
        public static TController Create<TController>(params object[] args)
            where TController : ControllerBase
        {
            var services = new ServiceCollection();
            services.AddTransient<IHandler, Handler>();

            var serviceProvider = services.BuildServiceProvider();
            var controller = serviceProvider.GetService<TController>();

            return controller;
        }
    }
}