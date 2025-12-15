namespace NetCoreWebApi.Server.Configurations
{
    public class DatabaseConfig
    {
        public readonly string ConnectionString = "Server=devserver;Database=DevDB;User Id=devuser;Password=devpassword;";
        public readonly string Provider = "SqlServer";
        public readonly bool EnableSensitiveDataLogging = true;
        public readonly int CommandTimeout = 60;
        public readonly int MaxRetryCount = 5;
    }
}
