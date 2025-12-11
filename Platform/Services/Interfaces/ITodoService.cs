using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreWebApi.Platform.Models;

namespace NetCoreWebApi.Platform.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<GetTodoResponse>> GetAllTodosAsync();
        Task<GetTodoResponse> GetTodoByIdAsync(int id);
        // Task<TodoDto> CreateTodoAsync(CreateTodoDto createTodoDto);
        // Task<TodoDto> UpdateTodoAsync(int id, UpdateTodoDto updateTodoDto);
        // Task<bool> DeleteTodoAsync(int id);
        // Task<bool> MarkTodoAsCompleteAsync(int id);
    }
}