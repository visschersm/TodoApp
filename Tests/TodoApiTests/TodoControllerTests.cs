using FluentAssertions;
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
        public async Task CreateTodoList_ValidRequest_OkObjectResult()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();
            Mock.Get(mockHandler).Setup(
                x => x.HandleCommand<CreateTodoListCommand, CreateTodoListCommandResult>(
                It.IsAny<CreateTodoListCommand>()))
                .ReturnsAsync(new CreateTodoListCommandResult
                {
                    Successfull = true,
                    Data = new ViewModel.TodoList.CreatedView()
                });

            var toCreate = new ViewModel.TodoList.CreateView();

            factory.Services.Replace(ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.CreateTodoList(toCreate);

            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.Should()
                .BeOfType<ViewModel.TodoList.CreatedView>();
        }

        [TestMethod]
        public async Task CreateTodoList_HandlerThrows_Rethrows()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();
            Mock.Get(mockHandler).Setup(
                x => x.HandleCommand<CreateTodoListCommand, CreateTodoListCommandResult>(
                    It.IsAny<CreateTodoListCommand>()))
                .ThrowsAsync(new Exception());

            var toCreate = new ViewModel.TodoList.CreateView();

            factory.Services.Replace(ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            Func<Task> act = async () => await controller.CreateTodoList(toCreate);

            await act.Should().ThrowAsync<Exception>();
        }

        [TestMethod]
        public async Task CreateTodoItem_ValidRequest_OkObjectResult()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();
            Mock.Get(mockHandler).Setup(
                x => x.HandleCommand<CreateTodoItemCommand, CreateTodoItemCommandResult>(
                    It.IsAny<CreateTodoItemCommand>()))
                .ReturnsAsync(new CreateTodoItemCommandResult
                {
                    Successfull = true,
                    Data = new ViewModel.TodoItem.CreatedView()
                });

            var toCreate = new ViewModel.TodoItem.CreateView();

            factory.Services.Replace(ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.CreateTodoItem(1, toCreate);

            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.Should().BeOfType<ViewModel.TodoItem.CreatedView>();
        }

        [TestMethod]
        public async Task CreateTodoItem_HandlerThrows_Rethrows()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();
            Mock.Get(mockHandler).Setup(
                x => x.HandleCommand<CreateTodoItemCommand, CreateTodoItemCommandResult>(
                    It.IsAny<CreateTodoItemCommand>()))
                .ThrowsAsync(new Exception());

            var toCreate = new ViewModel.TodoItem.CreateView();

            factory.Services.Replace(ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            Func<Task> act = async () => await controller.CreateTodoItem(1, toCreate);

            await act.Should().ThrowAsync<Exception>();
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
