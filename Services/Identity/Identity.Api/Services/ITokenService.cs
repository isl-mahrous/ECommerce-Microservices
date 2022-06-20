using Identity.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
