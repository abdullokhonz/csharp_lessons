using FinanceTracker.Exceptions;
using FinanceTracker.Models;
using Microsoft.Extensions.Logging;

namespace FinanceTracker.Services
{
    public class FinanceService : IFinanceService
    {
        // Тема 2: Разные коллекции под разные задачи
        private readonly List<Transaction> _transactions = new();
        private readonly HashSet<string> _categories = new();
        private Dictionary<string, decimal> _exchangeRates = new();

        private readonly ILogger<FinanceService> _logger;

        public FinanceService(ILogger<FinanceService> logger)
        {
            _logger = logger;
        }

        public void AddTransaction(string category, decimal amount, string currency, string? comment)
        {
            // Тема 3: Жесткая проверка на null через ArgumentNullException
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentNullException(nameof(category), "Категория не может быть пустой!");

            // Тема 1: Проверка бизнес-правила. Если не ок — взрываем кастомным исключением
            if (amount <= 0)
                throw new NegativeAmountException("Сумма транзакции должна быть строго больше нуля!");

            // Тема 3: Оператор ??= (присвоить значение, ЕСЛИ внутри null)
            comment ??= "Без комментария";

            var tx = new Transaction(Guid.NewGuid(), category.Trim(), amount, currency.ToUpper(), comment);

            _transactions.Add(tx);

            // Тема 2: HashSet. Метод Add возвращает false, если такая категория уже была.
            if (_categories.Add(tx.Category))
            {
                // Тема 7: Структурный лог уровня Debug (для внутренней кухни)
                _logger.LogDebug("В систему добавлена совершенно новая категория трат: {Category}", tx.Category);
            }

            _logger.LogInformation("Успешно добавлена транзакция в категории {Category} на сумму {Amount} {Currency}", tx.Category, tx.Amount, tx.Currency);
        }

        // Тема 2: Возвращаем IEnumerable вместо List, чтобы вызывающий код не мог делать .Add() напрямую
        public IEnumerable<Transaction> GetAllTransactions() => _transactions;

        public void SetRates(Dictionary<string, decimal> rates)
        {
            _exchangeRates = rates ?? throw new ArgumentNullException(nameof(rates));
        }

        public decimal CalculateTotalBalanceInUsd()
        {
            // Тема 5: Мощный LINQ. Проверяем, есть ли вообще транзакции
            if (!_transactions.Any()) return 0;

            // Считаем сумму через Sum с внутренней конвертацией
            return _transactions.Sum(t =>
            {
                if (t.Currency == "USD") return t.Amount;

                // Тема 3: Проверяем наличие курса в словаре. Если курса нет — берем 0 черезTryGetValue
                if (_exchangeRates.TryGetValue(t.Currency, out var rate) && rate != 0)
                {
                    return t.Amount / rate; // Перевод в USD
                }

                // Тема 7: Уровень Warning (что-то пошло не так, но приложение работает)
                _logger.LogWarning("Невозможно пересчитать транзакцию кошелька в валюте {Currency}, так как курс не загружен!", t.Currency);
                return 0;
            });
        }

        // Тема 4: Асинхронность и тест отмены через CancellationToken
        public async Task SimulateArchiveDownloadAsync(CancellationToken ct)
        {
            _logger.LogInformation("Старт скачивания архива прошлых лет...");

            for (int i = 1; i <= 5; i++)
            {
                // Метод Delay принимает токен отмены. Если токен отменен, он мгновенно выкинет OperationCanceledException
                // Тема 4: ConfigureAwait(false) убирает привязку к контексту потока
                await Task.Delay(1000, ct).ConfigureAwait(false);

                _logger.LogInformation("Скачивание архива: обработано {Percent}%...", i * 20);
            }

            _logger.LogInformation("Архив успешно скачан и интегрирован!");
        }
    }
}
