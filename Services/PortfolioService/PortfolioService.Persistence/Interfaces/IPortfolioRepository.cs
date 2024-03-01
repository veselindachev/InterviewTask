using PortfolioService.Persistence.Models;

namespace PortfolioService.Persistence.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<PortfolioDto> GetUserPortfolioAsync(int userId);
    }
}
