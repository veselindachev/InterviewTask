
using PortfolioService.Persistence.Interfaces;
using PortfolioService.Persistence.Models;
using PortfolioService.Service.Interfaces;
using Redis.Interfaces;

namespace PortfolioService.Service
{
    public class PortfolioManager : IPortfolioManager
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IRedisService _redisService;

        public PortfolioManager(IPortfolioRepository portfolioRepository, IRedisService redisService)
        {
            _portfolioRepository = portfolioRepository;
            _redisService = redisService;
        }

        public async Task<PortfolioDto> GetUserPortfolioAsync(int userId)
        {
            var portfolio = await _portfolioRepository.GetUserPortfolioAsync(userId);
            return portfolio;
        }
    }
}
