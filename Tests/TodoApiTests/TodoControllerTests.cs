using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MTech.Tests.Utilities;
using MTech.TodoApp.CQRS.Commands;
using MTech.TodoApp.CQRS.Requests;
using MTech.TodoApp.CQRS.Results;
using MTech.TodoApp.TodoApi;
using MTech.Utilities.RequestHandler;
using System;
using System.Threading.Tasks;
using ViewModel = MTech.TodoApp.ViewModel;

namespace MTech.Tests.TodoApiTests
{
    [TestClass]
    public class TodoControllerTests
    {
        [TestMethod]
        public async Task Create_ValidRequest_OkObjectResult()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();
            Mock.Get(mockHandler).Setup(
                x => x.HandleCommand<CreateTodoItemCommand, CreateTodoItemCommandResult>(
                It.IsAny<CreateTodoItemCommand>()))
                .ReturnsAsync(new CreateTodoItemCommandResult
                {
                    Successfull = true
                });

            var toCreate = new ViewModel.TodoList.CreateView();

            factory.Services.Replace(ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.Create(toCreate);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(
                ((OkObjectResult)result).Value,
                typeof(CreateTodoListCommandResult));
        }

        [TestMethod]
        public async Task Get_ValidRequest_OkObjectResult()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetAllTodoItemsQuery, TodoItemListViewResult>(
                    It.IsAny<GetAllTodoItemsQuery>()))
                .ReturnsAsync(new TodoItemListViewResult
                {
                    Successfull = true,
                });

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Get_HandlerThrows_ExceptionThrown()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetAllTodoItemsQuery, TodoItemListViewResult>(
                    It.IsAny<GetAllTodoItemsQuery>()))
                .ThrowsAsync(new Exception());

            factory.Services.Replace(ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            await Assert.ThrowsExceptionAsync<Exception>(async () =>
                await controller.Get());
        }
    }
}
