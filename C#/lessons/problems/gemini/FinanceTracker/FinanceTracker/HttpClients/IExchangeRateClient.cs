namespace FinanceTracker.HttpClients
{
    public interface IExchangeRateClient
    {
        Task<Dictionary<string, decimal>> GetRatesAsync(CancellationToken ct);
    }
}
