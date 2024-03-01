namespace PriceService.Service.Interfaces
{
    public interface IPriceServiceClient
    {
        Task<decimal> GetLatestPriceAsync(string stockTicker);
    }
}
