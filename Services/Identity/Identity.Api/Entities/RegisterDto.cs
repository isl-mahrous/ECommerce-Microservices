using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Entities
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
