using Identity.Api.Entities;
using Identity.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _service.Login(loginDto);
                return user;
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            try
            {
                var user = await _service.Register(registerDto);
                return user;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("testJwt")]
        [Authorize]
        public ActionResult<string> TestJwt()
        {
            return Ok("Valid Token");
        }

    }
}
