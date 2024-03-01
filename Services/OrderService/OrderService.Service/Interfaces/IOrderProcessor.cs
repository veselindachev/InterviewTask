using OrderService.Service.Models;

public interface IOrderProcessor
{
    Task ProcessOrderAsync(OrderDto orderDto);
}