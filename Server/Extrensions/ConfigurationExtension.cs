using NetCoreWebApi.Platform.Models.Configurations;

namespace NetCoreWebApi.Server.Extrensions
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            //1. Alternative way to bind configuration settings
            //services.Configure<DatabaseConfig>(configuration.GetSection("DatabaseConfig"));

            //2. Preferred way with validation
            services.AddOptions<DatabaseConfig>()
                .Bind(configuration.GetSection("DatabaseConfig"))
                .ValidateDataAnnotations()
                .Validate(config =>
                {
                    // Custom validation logic
                    return !string.IsNullOrEmpty(config.ConnectionString) && config.CommandTimeout > 0;
                }, "Custom validation failed: ConnectionString must not be empty and CommandTimeout must be greater than 0.")
                .ValidateOnStart();


            return services;
        }
    }
}
