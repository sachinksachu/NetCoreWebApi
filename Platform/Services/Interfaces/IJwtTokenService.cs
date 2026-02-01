using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using NetCoreWebApi.Platform.Models.Response;

namespace NetCoreWebApi.Platform.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(string userId, string username);
    }

}