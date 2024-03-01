using Moq;
using PriceService.Service;
using Redis.Interfaces;
using Xunit;

namespace PriceService.Test
{
    public class PriceGeneratorServiceTests
    {
        [Fact]
        public void GenerateRandomPrices_ReturnsCorrectNumberOfStocks()
        {
            // Arrange
            var priceGeneratorService = new PriceGeneratorService(new Mock<IRedisService>().Object);

            // Act
            var prices = priceGeneratorService.GenerateRandomPrices();

            // Assert
            Assert.NotNull(prices);
            Assert.NotEmpty(prices);
            Assert.Equal(2, prices.Count); // Assuming you have 2 predefined stocks
        }

        [Fact]
        public void GenerateRandomPrices_ReturnsPricesInRange()
        {
            // Arrange
            var priceGeneratorService = new PriceGeneratorService(new Mock<IRedisService>().Object);

            // Act
            var prices = priceGeneratorService.GenerateRandomPrices();

            // Assert
            Assert.All(prices.Values, price => Assert.InRange(price, 0, 1000)); // Assuming the maximum price is 1000
        }
    }
}
