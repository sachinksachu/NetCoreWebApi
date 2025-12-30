namespace NetCoreWebApi.Platform.Models.Configurations
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public bool EnableSensitiveDataLogging { get; set; }
        public int CommandTimeout { get; set; }
        public int MaxRetryCount { get; set; }
    }

}
