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
using ViewModel = MTech.TodoApp.ViewModel;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MTech.TodoApp.ViewModel;

namespace MTech.Tests.TodoApiTests
{
    [TestClass]
    public class TodoControllerTests
    {
        [TestMethod]
        public async Task Create_ValidRequest_OkObjectResult()
        {
            var factory = new ControllerFactory();

            var mockHandler = new Mock<IHandler>();

            mockHandler.Setup(
                x => x.HandleCommand<CreateTodoItemCommand, CreateTodoItemCommandResult>(
                    It.IsAny<CreateTodoItemCommand>()))
                .ReturnsAsync(new CreateTodoItemCommandResult
                {
                    Successfull = true      
                });

            var toCreate = new ViewModel.TodoItem.CreateView();

            var controller = factory.Create<TodoController>();

            var result = await controller.Create(toCreate);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(
                ((OkObjectResult)result).Value,
                typeof(CreateTodoItemCommandResult));
        }

        [TestMethod]
        public async Task Get_ValidRequest_OkObjectResult()
        {
            var factory = new ControllerFactory();

            var mockHandler = new Mock<IHandler>();

            mockHandler.Setup(
                x => x.HandleQuery<GetAllTodoItemsRequest<ViewModel.TodoItem.ListView>, TodoItemListViewResult<ViewModel.TodoItem.ListView>>(
                    It.IsAny<GetAllTodoItemsRequest<ViewModel.TodoItem.ListView>>()))
                .ReturnsAsync(new TodoItemListViewResult<ViewModel.TodoItem.ListView>
                {
                    Successfull = true,
                });

            var controller = factory.Create<TodoController>();

            var result = await controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Get_HandlerThrows_ExceptionThrown()
        {
            var factory = new ControllerFactory();

            var mockHandler = new Mock<IHandler>();

            mockHandler.Setup(
                x => x.HandleQuery<GetAllTodoItemsRequest<ViewModel.TodoItem.ListView>, 
                    TodoItemListViewResult<ViewModel.TodoItem.ListView>>(
                    It.IsAny<GetAllTodoItemsRequest<ViewModel.TodoItem.ListView>>()))
                .ThrowsAsync(new Exception());

            factory.Services.Replace(ServiceDescriptor.Transient(x => mockHandler.Object));

            var controller = factory.Create<TodoController>();

            await Assert.ThrowsExceptionAsync<Exception>(async () =>
                await controller.Get());
        }
    }
}
