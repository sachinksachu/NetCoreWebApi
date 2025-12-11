using Microsoft.Extensions.DependencyInjection;               // <-- Needed for IServiceCollection
using NetCoreWebApi.Platform.Services.Interfaces;             // <-- ITodoService
using NetCoreWebApi.Platform.Services;

namespace NetCoreWebApi.Platform.Services.Extensions;


public static class ServiceExtensionHandler
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }
}