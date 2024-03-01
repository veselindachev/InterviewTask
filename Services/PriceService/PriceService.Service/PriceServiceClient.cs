using PriceService.Service.Interfaces;
using StackExchange.Redis;

namespace PriceService.Service
{
    public class PriceServiceClient : IPriceServiceClient
    {
        private readonly IConnectionMultiplexer _redisConnection;

        public PriceServiceClient(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection ?? throw new ArgumentNullException(nameof(redisConnection));
        }

        public async Task<decimal> GetLatestPriceAsync(string stockTicker)
        {
            try
            {
                var db = _redisConnection.GetDatabase();

                var priceString = await db.StringGetAsync(stockTicker);

                if (priceString.HasValue && decimal.TryParse(priceString, out decimal price))
                {
                    return price;
                }
                else
                {
                    throw new InvalidOperationException("Price not available or invalid.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching price from Redis.", ex);
            }
        }
    }
}
