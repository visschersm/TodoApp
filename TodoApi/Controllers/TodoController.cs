using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTech.RequestHandler;
using MTech.TodoApp.TodoItem.Requests;
using MTech.TodoApp.TodoItem.Results;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _handler.HandleQuery<GetAllTodoItemsRequest, TodoItemListViewResult>(
                new GetAllTodoItemsRequest());

            if (!result.Succesfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _handler.HandleQuery<GetTodoItemByIdRequest, DetailedTodoItemViewResult>(
                new GetTodoItemByIdRequest(id));

            if(!result.Succesfull)
                return NotFound($"Could not find TodoItem with id: {id}");
            
            return Ok(result.Data);
        }
    }
}