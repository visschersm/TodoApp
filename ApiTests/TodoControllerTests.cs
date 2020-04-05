using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using MTech.ApiTests.Utilities;
using MTech.TodoApp.Api;
using Microsoft.Extensions.DependencyInjection;
using MTech.RequestHandler;

namespace ApiTests
{
    [TestClass]
    public class TodoControllerTests
    {
        [TestClass]
        public class Get
        {
            [TestMethod]
            public async Task ValidRequest_OkObjectResult()
            {
                var controller = ControllerFactory.Create<TodoController>();

                var result = await controller.Get();

                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            }
        }
    }
}
