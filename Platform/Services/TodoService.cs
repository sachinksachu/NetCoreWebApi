using NetCoreWebApi.Platform.Services.Interfaces;
using Microsoft.Extensions.Options;
using NetCoreWebApi.Platform.Models.Response;
using NetCoreWebApi.Server.Configurations;

namespace NetCoreWebApi.Platform.Services
{
    public class TodoService(IOptions<DatabaseConfig> databaseConfig) : ITodoService
    {
        private readonly DatabaseConfig _databaseConfig = databaseConfig.Value;
        public async Task<IEnumerable<GetTodoResponse>> GetAllTodosAsync()
        {
            return [];
        }

        public GetTodoResponse GetTodoByIdAsync(int id)
        {
            Console.WriteLine($"Database Connection String: {_databaseConfig.ConnectionString}");
            return new GetTodoResponse(_databaseConfig.MaxRetryCount,_databaseConfig.Provider, _databaseConfig.EnableSensitiveDataLogging);
        }
    }
}
