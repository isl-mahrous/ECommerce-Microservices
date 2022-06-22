using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Ordering.API.Controllers;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ordering.UnitTests
{
    public class OrdersControllerTests
    {
        private readonly Mock<IMediator> _mediatorStub = new();
        public OrdersControllerTests()
        {

        }
        [Fact]
        public async Task GetOrdersByUserName_ExistingUser_ReturnsOrdersList()
        {
            // Arrange
            var expectedOrders = new List<OrdersVm>() {
                new OrdersVm() {UserName = "isl", FirstName = "Islam", LastName = "Mahrous", EmailAddress = "isl.mahrous@gmail.com", AddressLine = "Sohag", Country = "Egypt", TotalPrice = 350 }            
            };
            _mediatorStub.Setup(o
                => o.Send(It.IsAny<GetOrdersListQuery>(), default)).ReturnsAsync(expectedOrders);

            var orderController = new OrderController(_mediatorStub.Object);

            // Act
            var actionResult = await orderController.GetOrdersByUserName("isl");
            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as List<OrdersVm>;

            // Assert
            actual.Should().BeEquivalentTo(expectedOrders, op => op.ComparingByMembers<OrdersVm>());
        }
    }
}
