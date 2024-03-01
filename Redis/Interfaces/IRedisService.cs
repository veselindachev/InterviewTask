namespace Redis.Interfaces
{
    public interface IRedisService
    {
        Task AddMessageToStreamAsync(string streamName, string message);
        Task PublishMessageAsync(string channel, string message);
    }
}
