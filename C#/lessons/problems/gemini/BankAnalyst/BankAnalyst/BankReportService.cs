namespace BankAnalyst
{
    public class BankReportService
    {
        private readonly int[] _transactions;

        public BankReportService(int[] transactions)
        {
            _transactions = transactions ?? throw new ArgumentNullException(nameof(transactions));
        }

        public (decimal Balance, decimal MaxExpense, bool Verify, bool Blocked) Analyze()
        {
            decimal currentBalance = 0m;
            decimal maxExpense = 0m;
            bool requiredVerification = false;
            bool isBlocked = false;

            foreach (var transaction in _transactions)
            {
                // Считаем баланс пошагово
                currentBalance += transaction;

                // Ищем максимальный расход
                if (transaction < 0)
                {
                    decimal absoluteExpense = Math.Abs((decimal)transaction);
                    if (absoluteExpense > maxExpense) maxExpense = absoluteExpense;
                }

                // Проверка на блокировку (проверяем ТЕКУЩИЙ баланс на каждом шагу)
                if (currentBalance < -1000) isBlocked = true;

                // Проверка на гигантские суммы (и доход, и расход)
                if (Math.Abs(transaction) > 100000) requiredVerification = true;
            }

            var result = (currentBalance, maxExpense, requiredVerification, isBlocked);

            return result;
        }

        public void PrintReport()
        {
            var (FinalBalance, MaxExpense, RequiredVerification, isBlocked) = Analyze();
            Console.WriteLine($"Final Balance: {FinalBalance:C}");
            Console.WriteLine($"Max Expense: {MaxExpense:C}");
            Console.WriteLine($"Required Verification: {RequiredVerification}");
            Console.WriteLine($"Account Blocked: {isBlocked}");
        }
    }
}
