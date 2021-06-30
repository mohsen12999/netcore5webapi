using System;
using System.Threading.Tasks;
using Catalog.Api.Controllers;
using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Catalog.UnitTests
{
    public class ItemControllerTests
    {
        [Fact]
        public async Task GetItemAsync_WithUnexistingItem_ReturnsNotFound()
        {
            // Arrange
            var repositoryStob = new Mock<IItemsRepositories>();
            repositoryStob.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Item)null);

            var loggerStub = new Mock<ILogger<ItemsController>>();

            var controller = new ItemsController(repositoryStob.Object, loggerStub.Object);

            // Act
            var result = await controller.GetItemAsync(new Guid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
