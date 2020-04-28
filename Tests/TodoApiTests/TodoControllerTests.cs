using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MTech.Tests.Utilities;
using MTech.TodoApp.CQRS.Commands;
using MTech.TodoApp.CQRS.Queries;
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
        public async Task CreateTodoList_NotSuccessful_StatusCodeInternalServerError()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();
            Mock.Get(mockHandler).Setup(
                x => x.HandleCommand<CreateTodoListCommand, CreateTodoListCommandResult>(
                It.IsAny<CreateTodoListCommand>()))
                .ReturnsAsync(new CreateTodoListCommandResult
                {
                    Successfull = false,
                });

            var toCreate = new ViewModel.TodoList.CreateView();

            factory.Services.Replace(ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.CreateTodoList(toCreate);

            result.Should().BeOfType<StatusCodeResult>();
            ((StatusCodeResult)result).StatusCode.Should()
                .Be(StatusCodes.Status500InternalServerError);
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
        public async Task CreateTodoItem_NotSucessfull_StatusCodeInternalServerError()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();
            Mock.Get(mockHandler).Setup(
                x => x.HandleCommand<CreateTodoItemCommand, CreateTodoItemCommandResult>(
                    It.IsAny<CreateTodoItemCommand>()))
                .ReturnsAsync(new CreateTodoItemCommandResult
                {
                    Successfull = false,
                });

            var toCreate = new ViewModel.TodoItem.CreateView();

            factory.Services.Replace(ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.CreateTodoItem(1, toCreate);

            result.Should().BeOfType<StatusCodeResult>();
            ((StatusCodeResult)result).StatusCode.Should()
                .Be(StatusCodes.Status500InternalServerError);
        }

        [TestMethod]
        public async Task GetTodoLists_ValidRequest_OkObjectResult()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetAllTodoListsQuery, TodoListsListViewQueryResult>(
                    It.IsAny<GetAllTodoListsQuery>()))
                .ReturnsAsync(new TodoListsListViewQueryResult
                {
                    Successfull = true,
                    Data = Array.Empty<ViewModel.TodoList.ListView>()
                });

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.GetTodoLists();

            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.Should()
                .BeOfType<ViewModel.TodoList.ListView[]>();
        }

        [TestMethod]
        public async Task GetTodoLists_NotSuccessful_StatusCodeInternalServerError()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetAllTodoListsQuery, TodoListsListViewQueryResult>(
                    It.IsAny<GetAllTodoListsQuery>()))
                .ReturnsAsync(new TodoListsListViewQueryResult
                {
                    Successfull = false,
                });

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.GetTodoLists();

            result.Should().BeOfType<StatusCodeResult>();
            ((StatusCodeResult)result).StatusCode.Should()
                .Be(StatusCodes.Status500InternalServerError);
        }

        [TestMethod]
        public async Task GetTodoLists_HandlerThrows_Rethrows()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetAllTodoListsQuery, TodoListsListViewQueryResult>(
                    It.IsAny<GetAllTodoListsQuery>()))
                .ThrowsAsync(new Exception());

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            Func<Task> act = async () => await controller.GetTodoLists();

            await act.Should().ThrowAsync<Exception>();
        }

        [TestMethod]
        public async Task GetTodoItemsByListId_ValidRequest_OkObjectResult()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetTodoItemsByListIdQuery, GetTodoItemsByListIdQueryResult>(
                    It.IsAny<GetTodoItemsByListIdQuery>()))
                .ReturnsAsync(new GetTodoItemsByListIdQueryResult
                {
                    Successfull = true,
                    Data = Array.Empty<ViewModel.TodoItem.ListView>()
                });

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.GetTodoItemsByListId(1);

            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.Should()
                .BeOfType<ViewModel.TodoItem.ListView[]>();
        }

        [TestMethod]
        public async Task GetTodoItemsByListId_HandlerThrows_Rethrows()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetTodoItemsByListIdQuery, GetTodoItemsByListIdQueryResult>(
                    It.IsAny<GetTodoItemsByListIdQuery>()))
                .ThrowsAsync(new Exception());

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            Func<Task> act = async () => await controller.GetTodoItemsByListId(1);

            await act.Should().ThrowAsync<Exception>();
        }

        [TestMethod]
        public async Task GetTodoItemsByListId_NotSuccessful_StatusCodeInternalServerError()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetTodoItemsByListIdQuery, GetTodoItemsByListIdQueryResult>(
                    It.IsAny<GetTodoItemsByListIdQuery>()))
                .ReturnsAsync(new GetTodoItemsByListIdQueryResult
                {
                    Successfull = false,
                });

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.GetTodoItemsByListId(1);

            result.Should().BeOfType<StatusCodeResult>();
            ((StatusCodeResult)result).StatusCode.Should()
                .Be(StatusCodes.Status500InternalServerError);
        }

        [TestMethod]
        public async Task GetTodoItemById_ValidRequest_OkObjectResult()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetTodoItemByIdQuery, GetTodoItemByIdQueryResult>(
                    It.IsAny<GetTodoItemByIdQuery>()))
                    .ReturnsAsync(new GetTodoItemByIdQueryResult
                    {
                        Successfull = true,
                        Data = new ViewModel.TodoItem.DetailedView()
                    });

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.GetTodoItemById(1, 1);

            result.Should().BeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.Should()
                .BeOfType<ViewModel.TodoItem.DetailedView>();
        }

        [TestMethod]
        public async Task GetTodoItemById_HandlerThrows_Rethrows()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetTodoItemByIdQuery, GetTodoItemByIdQueryResult>(
                    It.IsAny<GetTodoItemByIdQuery>()))
                    .ThrowsAsync(new Exception());

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            Func<Task> act = async () => await controller.GetTodoItemById(1, 1);

            await act.Should().ThrowAsync<Exception>();
        }

        public async Task GetTodoItemById_NotSuccessful_StatusCodeInternalServerError()
        {
            var factory = new ControllerFactory();

            var mockHandler = Mock.Of<IHandler>();

            Mock.Get(mockHandler).Setup(
                x => x.HandleQuery<GetTodoItemByIdQuery, GetTodoItemByIdQueryResult>(
                    It.IsAny<GetTodoItemByIdQuery>()))
                    .ReturnsAsync(new GetTodoItemByIdQueryResult
                    {
                        Successfull = false,
                    });

            factory.Services.Replace(
                ServiceDescriptor.Scoped(factory => mockHandler));

            var controller = factory.Create<TodoController>();

            var result = await controller.GetTodoItemById(1, 1);

            result.Should().BeOfType<StatusCodeResult>();
            ((StatusCodeResult)result).StatusCode.Should()
                .Be(StatusCodes.Status500InternalServerError);
        }
    }
}
