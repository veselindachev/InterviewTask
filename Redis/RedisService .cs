using Redis.Interfaces;
using StackExchange.Redis;

namespace PriceService.Service
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _redisConnection;

        public RedisService(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection ?? throw new ArgumentNullException(nameof(redisConnection));
        }

        public async Task AddMessageToStreamAsync(string streamName, string message)
        {
            try
            {
                var db = _redisConnection.GetDatabase();
                await db.StreamAddAsync(streamName, new[] { new NameValueEntry("message", message) });
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding message to Redis stream.", ex);
            }
        }

        public async Task PublishMessageAsync(string channel, string message)
        {
            try
            {
                var db = _redisConnection.GetDatabase();
                await db.PublishAsync(channel, message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error publishing message to Redis channel.", ex);
            }
        }
    }
}
