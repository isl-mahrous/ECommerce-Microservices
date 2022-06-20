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
    }
}
