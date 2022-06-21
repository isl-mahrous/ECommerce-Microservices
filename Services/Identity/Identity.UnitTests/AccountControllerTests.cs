using FluentAssertions;
using Identity.Api.Controllers;
using Identity.Api.Entities;
using Identity.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Identity.UnitTests
{
    public class AccountControllerTests
    {
        private readonly Mock<IAccountService> serviceStub = new();
        
        [Fact]
        public async Task Register_WithWeakPassword_ReturnsBadRequest()
        {
            // Arrange
            var registerDto = new RegisterDto() { Email = "isl.mahrous@gmail.com", Password = "123" };
            serviceStub.Setup(repo => repo.Register(registerDto)).Throws(new Exception());
            var controller = new AccountController(serviceStub.Object);

            // Act
            var actionResult = await controller.Register(registerDto);

            // Assert
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Fact]
        public async Task Register_WithValidInputs_ReturnsUserDto()
        {
            // Arrange
            var registerDto = new RegisterDto() { Email = "isl.ma@gmail.com", Password = "Islam@12345678" };
            var expected = new UserDto()
            {
                Email = "isl.ma@gmail.com",
                Token = "eyJhbGciOiJIUzUxMYWxob3N0OjgwMDMifQ.nY4S3bUtg2HdSVdjeQsdS_bXKjdCWKAkfg0en4-cLx5U63ijUo-mAnMAYXWXXTmcp4R9R_yW748nZKj-mdtr5w"
            };
            serviceStub.Setup(repo => repo.Register(registerDto)).ReturnsAsync(expected);
            var controller = new AccountController(serviceStub.Object);

            // Act
            var actionResult = await controller.Register(registerDto);
            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as UserDto;

            // Assert
            actual.Should().BeEquivalentTo(expected, op => op.ComparingByMembers<UserDto>());
        }
    }
}
