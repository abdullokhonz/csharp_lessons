namespace SmartAvia.HttpClients
{
    public interface IExchangeClient
    {
        Task<Dictionary<string, decimal>> GetExchangeRatesAsync(CancellationToken ct = default);
    }
}
