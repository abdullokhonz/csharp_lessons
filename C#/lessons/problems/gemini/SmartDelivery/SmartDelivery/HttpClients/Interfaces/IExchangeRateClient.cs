namespace SmartDelivery.HttpClients.Interfaces
{
    public interface IExchangeRateClient
    {
        Task<Dictionary<string, decimal>> GetExchangeRatesAsync(CancellationToken ct = default);
    }
}
