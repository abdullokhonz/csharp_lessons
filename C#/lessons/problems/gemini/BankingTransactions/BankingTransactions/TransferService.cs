namespace BankingTransactions
{
    public class TransferService
    {
        private readonly List<Account> _accounts;
        private readonly object _lockObject = new object(); // Для потокобезопасности

        public TransferService(List<Account> accounts) => _accounts = accounts;

        public void Transfer(int fromId, int toId, decimal amount)
        {
            // Поиск счетов
            var fromAccount = _accounts.FirstOrDefault(a => a.Id == fromId);
            var toAccount = _accounts.FirstOrDefault(a => a.Id == toId);

            // Валидация (Guard Clauses)
            if (fromAccount == null || toAccount == null)
            {
                Console.WriteLine("Ошибка: Один из счетов не найден.");
                return;
            }

            if (fromAccount.Balance < amount)
            {
                Console.WriteLine("Ошибка: Недостаточно средств.");
                return;
            }

            // Блокируем счета для этого потока, чтобы другие не могли списать деньги одновременно
            // В реальных БД это делается через транзакции БД
            lock (_lockObject)
            {
                bool isDebited = false;
                try
                {
                    // Списание
                    fromAccount.Balance -= amount;
                    isDebited = true;

                    // Конвертация валют
                    decimal rate = CurrencyConverter.GetExchangeRate(fromAccount.Currency, toAccount.Currency);
                    decimal finalAmount = amount * rate;

                    // Имитация сбоя (раскомментируй для теста отката)
                    // throw new Exception("Критическая ошибка сервера зачислений!");

                    // Зачисление
                    toAccount.Balance += finalAmount;

                    Console.WriteLine($"Успех! Переведено {amount} {fromAccount.Currency} -> {finalAmount} {toAccount.Currency}");
                }
                catch (Exception ex)
                {
                    // ОТКАТ (Только если списание уже произошло)
                    if (isDebited)
                    {
                        fromAccount.Balance += amount;
                        Console.WriteLine("Произведен откат: деньги возвращены на счет отправителя.");
                    }
                    Console.WriteLine($"Транзакция отменена: {ex.Message}");
                }
            }
        }
    }
}
