using Microsoft.EntityFrameworkCore;
using OrderService.Persistence.Models;

namespace OrderService.Persistence
{
    public class OrderDbContext : DbContext
    {
        internal List<Order> Orders = new List<Order>();

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Portfolios { get; set; }
    }
}
