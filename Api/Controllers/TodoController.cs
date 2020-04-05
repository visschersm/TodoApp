using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTech.RequestHandler;
using MTech.Application.TodoItem.Requests;
using Microsoft.AspNetCore.Http;

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
            var result = await _handler.Handle(new GetAllTodoItemsRequest());

            if(!result.Succesfull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}