using Basket.API.Services;
using System;
using Xunit;
using Moq;
using Basket.API.Entities;
using Basket.API.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace Basket.UnitTests
{
    public class CartControllerTests
    {
        private readonly Mock<ICartService> serviceStub = new();
        
        [Fact]
        public async Task GetCart_NonExixtingCartForUser_ReturnsNewCart()
        {
            // Arrange
            var expected = new Cart() { UserName = "isl", Items = new() };
            
            serviceStub.Setup(repo => repo.GetCart("isl")).ReturnsAsync(expected);

            var controller = new CartController(serviceStub.Object);

            // Act

            var actionResult = await controller.GetCart("isl");
            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as Cart;

            // Assert
            actual.Should().BeEquivalentTo(expected, op => op.ComparingByMembers<Cart>());
        }

        [Fact]
        public async Task GetCart_ExixtingCartForUser_ReturnsCurrentCart()
        {
            // Arrange
            var expectedCart = new Cart() { UserName = "isl", Items = new() { 
                new CartItem() { ProductId = "123", Color = "red", Price = 1200, ProductName="Laptop", Quantity = 1},
                new CartItem() { ProductId = "124", Color = "blue", Price = 1200, ProductName = "Mobile", Quantity = 1 },
                new CartItem() { ProductId = "125", Color = "green", Price = 1200, ProductName = "Whatever", Quantity = 1 },
            } };
            var expectedTotal = 3*1200;

            serviceStub.Setup(repo => repo.GetCart("isl")).ReturnsAsync(expectedCart);

            var controller = new CartController(serviceStub.Object);

            // Act

            var actionResult = await controller.GetCart("isl");
            var result = actionResult.Result as OkObjectResult;
            var actualCart = result.Value as Cart;
            var actualTotal = actualCart.TotalPrice;

            // Assert
            actualCart.Should().BeEquivalentTo(expectedCart);
            actualTotal.Should().Be(expectedTotal);
        }
    }
}
