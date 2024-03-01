using Microsoft.EntityFrameworkCore;
using PortfolioService.Persistence.Models;

namespace PortfolioService.Persistence
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }

        public DbSet<PortfolioDto> Portfolios { get; set; }
    }
}
