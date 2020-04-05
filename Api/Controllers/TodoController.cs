using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTech.RequestHandler;
using MTech.TodoApp.TodoItem.Requests;
using MTech.TodoApp.TodoItem.Results;
using System.Threading.Tasks;

namespace MTech.TodoApp.Api
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
            var result = await _handler.HandleQueryAsync<GetAllTodoItemsRequest, TodoItemListViewResult>(new GetAllTodoItemsRequest());

            if (!result.Succesfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.TodoItemList);
        }
    }
}