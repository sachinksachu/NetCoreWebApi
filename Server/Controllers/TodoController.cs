using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Platform.Models.Attributes;
using NetCoreWebApi.Platform.Services.Interfaces;

namespace NetCoreWebApi.Server.Controllers
{
    [ApiController] //Marker Attribute Patten example.
    [Route("api/[controller]")]
    
    public class TodoController(ITodoService todoService) : ControllerBase
    {
        #region Private Fields

        private readonly ITodoService _todoService = todoService;

        #endregion

        #region Controllers

        [HttpGet("{id}")]
        [RequireApiKey] //Marker Attribute Patten example.
        public IActionResult GetTodo(int id)
        {
            _todoService.GetTodoByIdAsync(id);
            return Ok();
            // TODO: Implement logic to retrieve todo by id
            //return Ok(new { id, title = "Sample Todo", completed = false });

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        #endregion
    }
}