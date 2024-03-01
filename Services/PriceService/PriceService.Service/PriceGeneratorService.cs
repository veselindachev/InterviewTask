using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PriceService.Service.Interfaces;
using Redis.Interfaces;

namespace PriceService.Service
{
    public class PriceGeneratorService : BackgroundService
    {
        private readonly IRedisService _redisService;

        public PriceGeneratorService(IRedisService redisService)
        {
            _redisService = redisService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Generate random prices for stocks and send them via Redis
                var randomPrices = GenerateRandomPrices();
                await _redisService.PublishMessageAsync("price-channel", JsonConvert.SerializeObject(randomPrices));
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }

        public Dictionary<string, decimal> GenerateRandomPrices()
        {
            // Generate random prices for predefined stocks
            var random = new Random();
            var prices = new Dictionary<string, decimal>
            {
                { "AAPL", (decimal)random.NextDouble() * 1000 },
                { "TSLA", (decimal)random.NextDouble() * 2000 },
            };

            return prices;
        }
    }

}
