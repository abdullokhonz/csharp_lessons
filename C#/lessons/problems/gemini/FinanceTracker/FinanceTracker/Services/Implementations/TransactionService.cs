using FinanceTracker.Models;
using FinanceTracker.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FinanceTracker.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly List<Transaction> _transactions;
        private readonly HashSet<string> _categories;
        private readonly Dictionary<string, decimal> _rates;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(
            List<Transaction> transactions,
            HashSet<string> categories,
            ILogger<TransactionService> logger)
        {
            _transactions = transactions ?? throw new ArgumentNullException(nameof(transactions));
            _categories = categories ?? throw new ArgumentNullException(nameof(categories));
            _rates = new Dictionary<string, decimal>();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Transaction>> ShowAllTransaction(CancellationToken ct)
        {
            if (_transactions.Any())
            {
                Console.WriteLine("Транзакций пока нет.");
                return Enumerable.Empty<Transaction>();
            }

            var sortedTransactions = _transactions.OrderByDescending(t => t.Amount).ToList();

            Console.WriteLine("=== Все транзакции ===");
            foreach (var transaction in sortedTransactions)
            {
                Console.WriteLine($"ID: {transaction.Id}");
                Console.WriteLine($"Категория: {transaction.Category}");
                Console.WriteLine($"Сумма: {transaction.Amount} {transaction.Currency}");
                if (!string.IsNullOrEmpty(transaction.Comment))
                    Console.WriteLine($"Комментарий: {transaction.Comment}");
                Console.WriteLine(new string('-', 30));
            }

            return sortedTransactions;
        }
    }
}
