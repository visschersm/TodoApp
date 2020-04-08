using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using MTech.Tests.Utilities;
using MTech.RequestHandler;
using MTech.TodoApp.TodoApi;
using MTech.TodoApp.TodoItem.Requests;
using MTech.TodoApp.TodoItem.Results;
using MTech.TodoApp.TodoItem.Commands;
using MTech.TodoApp.ViewModel;

namespace MTech.Tests.TodoApiTests
{
    [TestClass]
    public class TodoControllerTests : IBaseTest
    {
        private readonly Mock<IHandler> _mockHandler = new Mock<IHandler>();

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IHandler>(factory => _mockHandler.Object);
        }

        [TestMethod]
        public async Task Create_ValidRequest_OkObjectResult()
        {
            _mockHandler.Setup(
                x => x.HandleCommand<CreateTodoItemCommand, CreateTodoItemCommandResult>(
                    It.IsAny<CreateTodoItemCommand>()))
                .ReturnsAsync(new CreateTodoItemCommandResult
                {
                    Successfull = true      
                });

            var toCreate = new MTech.TodoApp.ViewModel.TodoItem.CreateView();

            var controller = ControllerFactory.Create<TodoController>(this);

            var result = await controller.Create(toCreate);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(
                ((OkObjectResult)result).Value,
                typeof(CreateTodoItemCommandResult));
        }

        [TestMethod]
        public async Task Get_ValidRequest_OkObjectResult()
        {
            _mockHandler.Setup(
                x => x.HandleQuery<GetAllTodoItemsRequest, TodoItemListViewResult>(
                    It.IsAny<GetAllTodoItemsRequest>()))
                .ReturnsAsync(new TodoItemListViewResult
                {
                    Successfull = true,
                });

            var controller = ControllerFactory.Create<TodoController>(this);

            var result = await controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Get_HandlerThrows_ExceptionThrown()
        {
            _mockHandler.Setup(
                x => x.HandleQuery<GetAllTodoItemsRequest, TodoItemListViewResult>(
                    It.IsAny<GetAllTodoItemsRequest>()))
                .ThrowsAsync(new Exception());

            var controller = ControllerFactory.Create<TodoController>(this);

            await Assert.ThrowsExceptionAsync<Exception>(async () =>
                await controller.Get());
        }
    }
}
