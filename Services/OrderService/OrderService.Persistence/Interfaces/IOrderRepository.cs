using OrderService.Persistence.Models;

namespace OrderService.Persistence.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
    }

}
    