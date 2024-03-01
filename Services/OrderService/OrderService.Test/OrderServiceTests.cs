namespace OrderService.Test
{
    using Xunit;
    using Moq;
    using System.Threading.Tasks;
    using OrderService.Service.Models;
    using OrderService.API.Controllers;
    using Microsoft.AspNetCore.Mvc;

    public class OrderControllerTests
    {
        [Fact]
        public async Task PlaceOrder_ValidOrder_ReturnsOkResult()
        {
            // Arrange
            var orderDto = new OrderDto {};
            var mockOrderProcessor = new Mock<IOrderProcessor>();
            mockOrderProcessor.Setup(p => p.ProcessOrderAsync(orderDto)).Returns(Task.CompletedTask);
            var controller = new OrderController(mockOrderProcessor.Object);

            // Act
            var result = await controller.PlaceOrder(orderDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }

}
