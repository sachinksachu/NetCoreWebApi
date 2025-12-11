using NetCoreWebApi.Platform.Services.Interfaces;
using NetCoreWebApi.Platform.Models;

namespace NetCoreWebApi.Platform.Services
{
    public class TodoService : ITodoService
    {
        public async Task<IEnumerable<GetTodoResponse>> GetAllTodosAsync()
        {
            return new List<GetTodoResponse>();
        }

        public async Task<GetTodoResponse> GetTodoByIdAsync(int id)
        {
            return new GetTodoResponse();
        }
    }
}
