using FinanceTracker.Models;

namespace FinanceTracker.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> ShowAllTransaction(CancellationToken ct);
    }
}
