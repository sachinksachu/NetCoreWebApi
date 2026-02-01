using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Platform.Models.Attributes;
using NetCoreWebApi.Platform.Services.Interfaces;

namespace NetCoreWebApi.Server.Controllers
{
    [ApiController] //Marker Attribute Patten example.
    [Route("api/[controller]")]
    
    public class TodoController(ITodoService todoService, IUserService userService) : ControllerBase
    {
        #region Private Fields

        private readonly ITodoService _todoService = todoService;
        private readonly IUserService _userService = userService;

        #endregion

        #region Controllers

        [Authorize]
        [RequireApiKey] //Marker Attribute Patten example.
        [HttpGet("{id}")]
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

        [HttpPost]
        public IActionResult Login()
        {
            var response = _userService.LoginAsync();
            return Ok(response);
        }
        #endregion
    }
}

///<note>
///1. IActionResult is a core interface in ASP.NET Core that represents the outcome of a controller action.
///2. It provides flexibility by allowing actions to return different types of results (e.g., Ok(), NotFound(), Redirect()).
///</note>