using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTech.TodoApp.CQRS.Commands;
using MTech.TodoApp.CQRS.Queries;
using MTech.TodoApp.CQRS.Results;
using MTech.Utilities.RequestHandler;
using System.Threading.Tasks;

namespace MTech.TodoApp.TodoApi
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IHandler _handler;
        public TodoController(IHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ViewModel.TodoList.CreatedView), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateTodoList([FromBody] ViewModel.TodoList.CreateView toCreate)
        {
            var result = await _handler.HandleCommand<CreateTodoListCommand, CreateTodoListCommandResult>(
                new CreateTodoListCommand(toCreate));

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("{id}/Items")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ViewModel.TodoItem.CreatedView), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateTodoItem(int id, [FromBody] ViewModel.TodoItem.CreateView toCreate)
        {
            var result = await _handler.HandleCommand<CreateTodoItemCommand, CreateTodoItemCommandResult>(
                new CreateTodoItemCommand(id, toCreate));

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ViewModel.TodoList.ListView[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTodoLists()
        {
            var result = await _handler.HandleQuery<GetAllTodoListsQuery, TodoListsListViewQueryResult>(
                new GetAllTodoListsQuery());

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ViewModel.TodoList.DetailedView), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTodoListById(int id)
        {
            var result = await _handler.HandleQuery<GetTodoListByIdQuery, GetTodoListByIdQueryResult>(
                new GetTodoListByIdQuery(id));

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("{id}/Items")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ViewModel.TodoItem.ListView[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTodoItemsByListId(int id)
        {
            var result = await _handler.HandleQuery<GetTodoItemsByListIdQuery, GetTodoItemsByListIdQueryResult>(
                new GetTodoItemsByListIdQuery(id));

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("{parentId}/Items/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ViewModel.TodoItem.DetailedView), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTodoItemById(int parentId, int id)
        {
            var result = await _handler.HandleQuery<GetTodoItemByIdQuery, GetTodoItemByIdQueryResult>(
                new GetTodoItemByIdQuery(parentId, id));

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("{parentId}/Items/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ViewModel.TodoItem.ListView), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTodoItem(int parentId, int id, [FromBody] ViewModel.TodoItem.UpdateView toUpdate)
        {
            var result = await _handler.HandleCommand<UpdateTodoItemCommand, UpdateTodoItemCommandResult>(
                new UpdateTodoItemCommand(parentId, id, toUpdate));

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }
    }
}