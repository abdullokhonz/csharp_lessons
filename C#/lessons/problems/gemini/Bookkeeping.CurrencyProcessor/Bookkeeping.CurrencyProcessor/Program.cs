using Bookkeeping.CurrencyProcessor.HttpClients.Implementations;
using Bookkeeping.CurrencyProcessor.HttpClients.Interfaces;
using Bookkeeping.CurrencyProcessor.Models;
using Bookkeeping.CurrencyProcessor.Services.Implementations;
using Bookkeeping.CurrencyProcessor.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    // Тема 6: Конфигурируем HttpClient через IHttpClientFactory с базовым адресом и таймаутом в 4 секунды
    services.AddHttpClient<IExchangeRateClient, ExchangeRateClient>(client =>
    {
        client.BaseAddress = new Uri("https://open.er-api.com/v6/latest/");
        client.Timeout = TimeSpan.FromSeconds(4);
    });

    // Исправлено: Регистрируем интерфейс и его конкретную реализацию
    services.AddTransient<IWalletProcessor, WalletProcessor>();
});

var host = builder.Build();

var processor = host.Services.GetRequiredService<IWalletProcessor>();
var logger = host.Services.GetRequiredService<ILogger<Program>>();

// Генерируем тестовые данные
var fakeWallets = GenerateFakeWallets();

using var cts = new CancellationTokenSource();

// === ТЕСТ ОЙ СЦЕНАРИЙ №1: Обычный успешный запуск ===
try
{
    await processor.ProcessWalletsAsync(fakeWallets, cts.Token);
}
catch (Exception ex)
{
    logger.LogCritical(ex, "Приложение аварийно завершило работу!");
}

// === ТЕСТ ОЙ СЦЕНАРИЙ №2: Проверка отмены операции (Раскомментируй для теста) ===
/*
_header("ТЕСТ ОТМЕНЫ ОПЕРАЦИИ");
using var ctsCancel = new CancellationTokenSource();
ctsCancel.CancelAfter(100); // Отмена произойдет через 100мс посреди обработки

try
{
    await processor.ProcessWalletsAsync(fakeWallets, ctsCancel.Token);
}
catch (OperationCanceledException)
{
    logger.LogWarning("Система успешно отловила отмену токена и безопасно завершила потоки!");
}
*/

static List<Wallet> GenerateFakeWallets()
{
    var duplicateId = Guid.NewGuid();
    return new List<Wallet>
    {
        new Wallet(Guid.NewGuid(), "Иван", 1500.00m, "USD", "v:1"),
        new Wallet(Guid.NewGuid(), "Алексей", 2400.50m, "EUR", "v:2"),
        new Wallet(Guid.NewGuid(), "Мария", 150000.00m, "RUB", "invalid_metadata_format"), // Упадет в TryParse, но не взорвет код
        new Wallet(Guid.NewGuid(), "Ольга", -350.00m, "USD", null), // Кошелек с долгом для теста LINQ Any()
        new Wallet(Guid.NewGuid(), "Джон", 50.00m, "GBP", "v:3"),
        new Wallet(duplicateId, "Дубликат Тест 1", 100m, "EUR", null),
        new Wallet(duplicateId, "Дубликат Тест 2 (Должен отсечься)", 100m, "EUR", null), // Дубликат по ID для теста HashSet
    };
}
