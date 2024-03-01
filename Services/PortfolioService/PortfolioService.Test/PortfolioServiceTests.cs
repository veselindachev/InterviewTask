namespace PortfolioService.Test
{
    using Xunit;
    using Moq;
    using System.Threading.Tasks;
    using PortfolioService.Persistence.Interfaces;
    using PortfolioService.Service;
    using Redis.Interfaces;
    using PortfolioService.Persistence.Models;

    public class PortfolioServiceTests
    {
        public class PortfolioManagerTests
        {
            [Fact]
            public async Task GetUserPortfolioAsync_ReturnsUserPortfolio()
            {
                // Arrange
                int userId = 1;
                var expectedPortfolioDto = new PortfolioDto {};

                // Mock IPortfolioRepository
                var mockPortfolioRepository = new Mock<IPortfolioRepository>();
                mockPortfolioRepository.Setup(repo => repo.GetUserPortfolioAsync(userId))
                                       .ReturnsAsync(expectedPortfolioDto);

                // Mock IRedisService
                var mockRedisService = new Mock<IRedisService>();

                var portfolioManager = new PortfolioManager(mockPortfolioRepository.Object, mockRedisService.Object);

                // Act
                var result = await portfolioManager.GetUserPortfolioAsync(userId);

                // Assert
                Assert.NotNull(result);
            }
        }
    }

}
