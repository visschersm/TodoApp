using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MTech.RequestHandler;
using MTech.TodoApp.Api;
using MTech.TodoApp.ApiTests.Utilities;
using MTech.TodoApp.TodoItem.Requests;
using MTech.TodoApp.TodoItem.Results;
using System.Threading.Tasks;

namespace MTech.TodoApp.ApiTests
{
    [TestClass]
    public class TodoControllerTests : IBaseTest
    {
        private Mock<IHandler> _mockHandler => new Mock<IHandler>();

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient((factory) => { return _mockHandler.Object; });
        }

        [TestClass]
        public class Get : TodoControllerTests
        {
            [TestMethod]
            public async Task ValidRequest_OkObjectResult()
            {
                _mockHandler.Setup(
                    x => x.HandleQueryAsync<GetAllTodoItemsRequest, TodoItemListViewResult>(
                        It.IsAny<GetAllTodoItemsRequest>()))
                    .ReturnsAsync(new TodoItemListViewResult
                    {
                        Succesfull = true,
                        //TodoItemList = Array.Empty<TodoItemListView>()
                    });

                var controller = ControllerFactory.Create<TodoControllerTests, TodoController>(this);

                var result = await controller.Get();

                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            }
        }
    }
}
