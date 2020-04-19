using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTech.RequestHandler;
using MTech.TodoApp.TodoItem.Requests;
using MTech.TodoApp.TodoItem.Results;
using System.Threading.Tasks;
using MTech.TodoApp.TodoItem.Commands;
using MTech.TodoApp.ViewModel.TodoItem;

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
            
            if(!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ViewModel.TodoItem.ListView[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _handler.HandleQuery<GetAllTodoItemsRequest<ViewModel.TodoItem.ListView>, 
                TodoItemListViewResult<ViewModel.TodoItem.ListView>>(
                    new GetAllTodoItemsRequest<ViewModel.TodoItem.ListView>());

            if (!result.Successfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _handler.HandleQuery<GetTodoItemByIdRequest, DetailedTodoItemViewResult>(
                new GetTodoItemByIdRequest(id));

            if(!result.Successfull)
                return NotFound($"Could not find TodoItem with id: {id}");
            
            return Ok(result.Data);
        }
    }
}