using PortfolioService.Persistence.Models;

namespace PortfolioService.Service.Interfaces
{
    public interface IPortfolioManager
    {
        Task<PortfolioDto> GetUserPortfolioAsync(int userId);
    }
}
