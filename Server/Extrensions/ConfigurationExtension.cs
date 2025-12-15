using NetCoreWebApi.Server.Configurations;

namespace NetCoreWebApi.Server.Extrensions
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseConfig>(configuration.GetSection("DatabaseConfig"));
            
            return services;
        }
    }
}
