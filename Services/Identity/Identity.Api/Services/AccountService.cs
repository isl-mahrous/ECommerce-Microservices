using Identity.Api.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new Exception();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
            {
                throw new Exception();
            }

            return new UserDto
            {
                Email = dto.Email,
                Token = _tokenService.CreateToken(user)
            };
        }
        public async Task<UserDto> Register(RegisterDto dto)
        {
            var foundUser = await _userManager.FindByEmailAsync(dto.Email);

            if (foundUser != null) 
                throw new Exception();

            var user = new AppUser
            {
                Email = dto.Email,
                UserName = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded) 
                throw new Exception();

            return new UserDto
            {
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }
    }
}
