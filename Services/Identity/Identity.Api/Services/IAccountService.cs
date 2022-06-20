using Identity.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services
{
    public interface IAccountService
    {
        Task<UserDto> Login(LoginDto dto);
        Task<UserDto> Register(RegisterDto dto);

    }
}
