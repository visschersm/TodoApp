using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTech.TodoApp.CQRS.TodoItem.Commands;
using MTech.TodoApp.CQRS.TodoItem.Requests;
using MTech.TodoApp.CQRS.TodoItem.Results;
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
        [ProducesResponseType(typeof(ViewModel.TodoItem.CreatedView), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody]ViewModel.TodoItem.CreateView toCreate)
        {
            var result = await _handler.HandleCommand<CreateTodoItemCommand, CreateTodoItemCommandResult>(
                new CreateTodoItemCommand(toCreate));

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ViewModel.TodoItem.ListView[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _handler.HandleQueryAsync<GetAllTodoItemsRequest, TodoItemListViewResult>(
                new GetAllTodoItemsRequest());

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }
    }
}