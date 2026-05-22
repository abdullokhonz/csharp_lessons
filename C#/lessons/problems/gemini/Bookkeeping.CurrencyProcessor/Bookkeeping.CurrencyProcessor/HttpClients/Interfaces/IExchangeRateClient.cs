namespace Bookkeeping.CurrencyProcessor.HttpClients.Interfaces
{
    public interface IExchangeRateClient
    {
        Task<Dictionary<string, decimal>> GetLatestRatesAsync(CancellationToken ct);
    }
}
