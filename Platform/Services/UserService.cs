using NetCoreWebApi.Platform.Services.Interfaces;
using Microsoft.Extensions.Options;
using NetCoreWebApi.Platform.Models.Response;
using NetCoreWebApi.Platform.Models.Configurations;

namespace NetCoreWebApi.Platform.Services
{
    public class UserService(IOptions<DatabaseConfig> databaseConfig, IOptions<JwtConfig> jwtConfig,
        IJwtTokenService jwtTokenService) : IUserService
    {
        private readonly DatabaseConfig _databaseConfig = databaseConfig.Value;
        private readonly JwtConfig _jwtConfig = jwtConfig.Value;
        private readonly IJwtTokenService _jwtTokenService = jwtTokenService;
        public UserLoginResponse LoginAsync()
        {
            string jwtToken = _jwtTokenService.GenerateToken("sampleUserId","username");

            return new UserLoginResponse(jwtToken);
        }
    }
}
