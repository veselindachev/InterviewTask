using OrderService.Persistence.Interfaces;
using OrderService.Service.Models;
using PriceService.Service.Interfaces;
using Redis.Interfaces;

namespace OrderService.Service
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRedisService _redisService;
        private readonly IPriceServiceClient _priceServiceClient;

        public OrderProcessor(IOrderRepository orderRepository, IRedisService redisService, IPriceServiceClient priceServiceClient)
        {
            _orderRepository = orderRepository;
            _redisService = redisService;
            _priceServiceClient = priceServiceClient;
        }

        public async Task ProcessOrderAsync(OrderDto orderDto)
        {
            // Execution of the order
            var latestPrice = await _priceServiceClient.GetLatestPriceAsync(orderDto.StockTicker);

            // Store order details in PostgreSQL
            var order = new Persistence.Models.Order { UserId = orderDto.UserId, StockTicker = orderDto.StockTicker, Quantity = orderDto.Quantity, Side = orderDto.Side, Price = latestPrice };
            await _orderRepository.AddOrderAsync(order);

            // Add a message to Redis Stream
            await _redisService.AddMessageToStreamAsync("order-stream", order.ToString());

            // Notify other microservices via pub/sub
            await _redisService.PublishMessageAsync("order-channel", "New order placed");
        }
    }
}
