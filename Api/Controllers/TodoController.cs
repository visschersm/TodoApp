using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MTech.TodoApp
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
            _handler.Handle(new GetAllTodoItemsRequest());
        }
    }
}