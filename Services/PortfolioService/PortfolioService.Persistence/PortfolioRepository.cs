using Microsoft.EntityFrameworkCore;
using PortfolioService.Persistence;
using PortfolioService.Persistence.Interfaces;
using PortfolioService.Persistence.Models;

public class PortfolioRepository : IPortfolioRepository
{
    private readonly PortfolioDbContext _dbContext;

    public PortfolioRepository(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<PortfolioDto> GetUserPortfolioAsync(int userId)
    {
        var userPortfolio = await _dbContext.Portfolios
            .Where(p => p.UserId == userId)
            .Select(p => new PortfolioDto { UserId = p.UserId, PortfolioValue = p.PortfolioValue })
            .FirstOrDefaultAsync();

        return userPortfolio;
    }
}
