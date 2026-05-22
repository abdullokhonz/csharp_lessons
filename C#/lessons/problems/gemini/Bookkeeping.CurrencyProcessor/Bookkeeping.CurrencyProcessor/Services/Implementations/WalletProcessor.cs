using Bookkeeping.CurrencyProcessor.HttpClients.Interfaces;
using Bookkeeping.CurrencyProcessor.Models;
using Bookkeeping.CurrencyProcessor.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Bookkeeping.CurrencyProcessor.Services.Implementations
{
    public class WalletProcessor : IWalletProcessor
    {
        private readonly IExchangeRateClient _exchangeRateClient;
        private readonly ILogger<WalletProcessor> _logger;

        public WalletProcessor(IExchangeRateClient exchangeRateClient, ILogger<WalletProcessor> logger)
        {
            _exchangeRateClient = exchangeRateClient;
            _logger = logger;
        }

        public async Task ProcessWalletsAsync(IEnumerable<Wallet> wallets, CancellationToken ct)
        {
            // Тема 3: Жесткая проверка на null на входе
            ArgumentNullException.ThrowIfNull(wallets);

            _logger.LogInformation("Старт процессинга кошельков.");

            // Теma 2: Храним историю аудита во внутренней Очереди (Queue)
            var auditQueue = new Queue<AuditRecord>();

            // Тема 2: HashSet для контроля уникальности. Исключаем дубликаты кошельков во входящих данных
            var uniqueWalletIds = new HashSet<Guid>();
            var filteredWallets = new List<Wallet>();

            foreach (var wallet in wallets)
            {
                // Тема 3: Null-conditional оператор
                if (wallet?.Id == null) continue;

                if (uniqueWalletIds.Add(wallet.Id))
                {
                    filteredWallets.Add(wallet);
                }
                else
                {
                    _logger.LogWarning("Обнаружен дубликат кошелька {WalletId} во входящих данных. Пропускаем.", wallet.Id);
                }
            }

            // Получаем курсы валют
            Dictionary<string, decimal> rates = await _exchangeRateClient.GetLatestRatesAsync(ct).ConfigureAwait(false);

            // Тема 4: Parallel Processing через Task.WhenAll
            // Создаем массив задач. Каждая задача обрабатывает один кошелек асинхронно
            var tasks = filteredWallets.Select(async wallet =>
            {
                // Проверка токена отмены перед тяжелой операцией
                ct.ThrowIfCancellationRequested();

                _logger.LogDebug("Обработка кошелька {WalletId} ({Currency}) пользователя {User}...", wallet.Id, wallet.Currency, wallet.User);

                // Симуляция асинхронной работы (например, запись в бд)
                await Task.Delay(200, ct).ConfigureAwait(false);

                // Тема 1: Когда НЕ надо использовать исключения. Парсинг кастомных метаданных кошелька.
                // Вместо try-catch используем безопасный TryParse pattern.
                if (TryParseMetadataVersion(wallet.Metadata, out int version))
                {
                    _logger.LogDebug("Метаданные кошелька {WalletId} распарсены. Версия: {Version}", wallet.Id, version);
                }

                if (rates.TryGetValue(wallet.Currency, out var rate))
                {
                    // Считаем эквивалент в USD (В API за базу взят USD, значит: Balance / Rate)
                    decimal balanceInUsd = rate != 0 ? wallet.Balance / rate : 0;

                    string logMessage = $"Кошелек {wallet.Id} успешно пересчитан: {balanceInUsd:F2} USD.";

                    // Потокобезопасность для учебного примера упрощена (lock для очереди)
                    lock (auditQueue)
                    {
                        auditQueue.Enqueue(new AuditRecord(Guid.NewGuid(), DateTimeOffset.UtcNow, logMessage));
                    }
                }
                else
                {
                    // Тема 7: Уровень лога Warning для аномалий бизнес-логики
                    _logger.LogWarning("Курс для валюты {Currency} (кошелек {WalletId}) не найден во внешнем API!", wallet.Currency, wallet.Id);
                }
            });

            try
            {
                // Запускаем всё параллельно пачкой
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при параллельной обработке пачки кошельков.");
                throw;
            }
            finally
            {
                // Тема 1: Блок finally гарантирует выполнение кода очистки ресурсов или финального вывода
                _logger.LogInformation("--- СБРОС БУФЕРА АУДИТА (ОЧЕРЕДЬ) ---");
                while (auditQueue.Count > 0)
                {
                    var audit = auditQueue.Dequeue();
                    _logger.LogInformation("[AUDIT] [{Timestamp}] {Message}", audit.Timestamp, audit.Message);
                }
                _logger.LogInformation("Блок процессинга кошельков завершил работу.");
            }

            // Тема 5: Демонстрация мощностей LINQ над результатами в памяти
            ExecuteAnalyticsReport(filteredWallets, rates);
        }

        // Тема 1: Реализация паттерна TryParse (Никаких исключений при неверном формате строки!)
        private bool TryParseMetadataVersion(string? metadata, out int version)
        {
            version = 0;
            if (string.IsNullOrWhiteSpace(metadata)) return false;

            // Допустим формат метаданных: "v:2"
            if (metadata.StartsWith("v:") && int.TryParse(metadata.AsSpan(2), out int parsedVersion))
            {
                version = parsedVersion;
                return true;
            }
            return false;
        }

        private void ExecuteAnalyticsReport(List<Wallet> wallets, Dictionary<string, decimal> rates)
        {
            _logger.LogInformation("--- АНАЛИТИЧЕСКИЙ ОТЧЕТ (LINQ) ---");

            // 1. Where, Select, OrderByDescending, Skip, Take (Пагинация: Топ-3 самых богатых кошелька в USD)
            var top3Wallets = wallets
                .Where(w => rates.ContainsKey(w.Currency))
                .Select(w => new
                {
                    w.User,
                    w.Currency,
                    w.Balance,
                    BalanceInUsd = rates[w.Currency] != 0 ? w.Balance / rates[w.Currency] : 0
                })
                .OrderByDescending(w => w.BalanceInUsd)
                .Take(3); // Фильтрация топ-3

            _logger.LogInformation("Топ-3 самых крупных кошельков системы:");
            foreach (var item in top3Wallets)
            {
                _logger.LogInformation("Пользователь: {User} | Баланс: {Balance} {Currency} ({Usd:F2} USD)", item.User, item.Balance, item.Currency, item.BalanceInUsd);
            }

            // 2. Any / All
            bool hasNegativeBalances = wallets.Any(w => w.Balance < 0);
            _logger.LogInformation("Есть ли в системе кошельки с долгами (отрицательный баланс)? {Result}", hasNegativeBalances ? "Да!" : "Нет");

            // 3. First / Single (Братья OrDefault)
            // Ищем первый попавшийся рублевый кошелек
            var firstRubWallet = wallets.FirstOrDefault(w => w.Currency == "RUB");
            if (firstRubWallet != null)
            {
                _logger.LogInformation("Найден первый кошелек в RUB: Пользователь {User}, Баланс {Balance}", firstRubWallet.User, firstRubWallet.Balance);
            }
        }
    }
}
