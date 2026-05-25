using FinanceTracker.Models;

namespace FinanceTracker.Services
{
    public interface IFinanceService
    {
        void AddTransaction(string category, decimal amount, string currency, string? comment);
        IEnumerable<Transaction> GetAllTransactions();
        void SetRates(Dictionary<string, decimal> rates);
        decimal CalculateTotalBalanceInUsd();
        Task SimulateArchiveDownloadAsync(CancellationToken ct);
    }
}
