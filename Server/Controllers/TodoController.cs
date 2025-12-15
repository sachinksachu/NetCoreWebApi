using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Platform.Services.Interfaces;

namespace NetCoreWebApi.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController(ITodoService todoService) : ControllerBase
    {
        #region Private Fields
        private readonly ITodoService _todoService = todoService;
        #endregion

        [HttpGet("{id}")]
        public IActionResult GetTodo(int id)
        {
            _todoService.GetTodoByIdAsync(id);
            return Ok();
            // TODO: Implement logic to retrieve todo by id
            //return Ok(new { id, title = "Sample Todo", completed = false });


        }
    }
}