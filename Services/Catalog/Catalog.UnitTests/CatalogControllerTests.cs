using Catalog.API.Controllers;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.UnitTests
{
    public class CatalogControllerTests
    {
        private readonly Mock<IProductRepository> repositoryStub = new();
        private readonly Mock<ILogger<CatalogController>> loggerStub = new();
        private readonly Random rand = new();


        [Fact]
        public async Task GetProducts_WithExistingProducts_ReturnsProductsList()
        {
            //Arrange
            IEnumerable<Product> expectedItems = new List<Product> { GetProduct(), GetProduct(), GetProduct() };
            
            repositoryStub.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedItems);

            var controller = new CatalogController(repositoryStub.Object, loggerStub.Object);

            //Act
            var actualItems = await controller.GetProducts();

            //Assert
            actualItems.Should().BeEquivalentTo(expectedItems);

        }

        [Fact]
        public async Task GetProduct_WithUnexistingId_ReturnsNotFound()
        {
            //Arrange
            var expectedItem = GetProduct();

            repositoryStub.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>().ToString()))
                .ReturnsAsync(expectedItem);

            var controller = new CatalogController(repositoryStub.Object, loggerStub.Object);

            //Act
            var actualItem = await controller.GetProductById(Guid.NewGuid().ToString());

            //Assert
            Assert.IsType<NotFoundResult>(actualItem.Result);

        }

        [Fact]
        public async Task GetProduct_WithEexistingId_ReturnsProduct()
        {
            //Arrange
            var expectedItem = GetProduct();

            repositoryStub.Setup(repo => repo.GetByIdAsync(expectedItem.Id))
                .ReturnsAsync(expectedItem);

            var controller = new CatalogController(repositoryStub.Object, loggerStub.Object);

            //Act
            var actionResult = await controller.GetProductById(expectedItem.Id);
            var result = actionResult.Result as OkObjectResult;
            var actualItem = result.Value as Product;

            //Assert

            actualItem.Should().BeEquivalentTo(expectedItem, op => op.ComparingByMembers<Product>());

        }

        ////////// Helper Functions ////////
        private Product GetProduct()
        {
            return new Product {
                Id = Guid.NewGuid().ToString(),
                Name = "Random Product",
                Description = "Random Description",
                Price = rand.Next(0, 10000)
            };
        }
    }
}
