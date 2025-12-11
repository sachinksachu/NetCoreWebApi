using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApi.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetTodo(int id)
        {
            // TODO: Implement logic to retrieve todo by id
            return Ok(new { id, title = "Sample Todo", completed = false });
        }
    }
}