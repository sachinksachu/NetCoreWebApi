using Microsoft.Extensions.DependencyInjection;               // <-- Needed for IServiceCollection
using NetCoreWebApi.Platform.Services.Interfaces;             // <-- ITodoService

namespace NetCoreWebApi.Platform.Services.Extensions;

public static class ServiceExtensionHandler
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }
}

/// <note>
/// Important rules for Extension methods
///The method must be static
///The class must be static
///The first parameter must use 'this'
///The namespace must be in scope(using YourNamespace;)
/// </note>