using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreWebApi.Platform.Models.Response;

namespace NetCoreWebApi.Platform.Services.Interfaces
{
    public interface IUserService
    {
        UserLoginResponse LoginAsync();
    }
}