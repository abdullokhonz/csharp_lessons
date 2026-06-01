using Microsoft.Extensions.Logging;
using SmartUptime.CLI.Entities;
using SmartUptime.CLI.HttpClients.Interfaces;
using SmartUptime.CLI.Services.Interfaces;
using System.Diagnostics;

namespace SmartUptime.CLI.Services.Implementations;

public class UptimeMonitorService : IUptimeMonitorService
{
    // Потокобезопасный доступ (так как таски будут писать сюда параллельно)
    private readonly List<ServicePingResult> _history = new();
    private readonly object _lock = new();

    private readonly ITestClient _testClient;
    private readonly ILogger<UptimeMonitorService> _logger;

    public UptimeMonitorService(ITestClient testClient, ILogger<UptimeMonitorService> logger)
    {
        _testClient = testClient ?? throw new ArgumentNullException(nameof(testClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task RunMetricsCheckAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("Запуск параллельной проверки метрик...");

        // Запускаем задачи одновременно БЕЗ await
        var tasks = new List<Task>
        {
            CheckEndpointAsync("Users", _testClient.GetUsersAsync, ct),
            CheckEndpointAsync("Posts", _testClient.GetPostsAsync, ct),
            CheckEndpointAsync("Comments", _testClient.GetCommentsAsync, ct)
        };

        // Ждем завершения всех (даже если кто-то упадет, внутренний try-catch в CheckEndpointAsync это обработает)
        await Task.WhenAll(tasks).ConfigureAwait(false);

        _logger.LogInformation("Параллельный опрос всех метрик успешно завершен.");
    }

    // Вспомогательный метод для параллельного замера и безопасной записи результатов
    private async Task CheckEndpointAsync(string name, Func<CancellationToken, Task<IEnumerable<int>>> fetchFunc, CancellationToken ct)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var result = await fetchFunc(ct).ConfigureAwait(false);
            sw.Stop();

            lock (_lock)
            {
                _history.Add(new ServicePingResult(name, true, sw.ElapsedMilliseconds, null, DateTime.UtcNow));
            }
            _logger.LogInformation("Сервис {Name} ДОСТУПЕН. Время: {Time} мс. Элементов: {Count}", name, sw.ElapsedMilliseconds, result.Count());
        }
        catch (Exception ex)
        {
            sw.Stop();
            lock (_lock)
            {
                _history.Add(new ServicePingResult(name, false, sw.ElapsedMilliseconds, ex.Message, DateTime.UtcNow));
            }
            _logger.LogWarning("Сервис {Name} НЕДОСТУПЕН! Время: {Time} мс. Причина: {Error}", name, sw.ElapsedMilliseconds, ex.Message);

            // Если была системная отмена (cts.Cancel) — пробрасываем наверх для обработки в App.cs
            if (ex is OperationCanceledException) throw;
        }
    }

    public IEnumerable<ServicePingResult> GetHistory()
    {
        lock (_lock)
        {
            return _history.ToList(); // Возвращаем копию списка во избежание проблем многопоточного чтения
        }
    }

    // Тема LINQ: Считаем среднее время только для успешных
    public double GetAverageResponseTime()
    {
        lock (_lock)
        {
            return _history
                .Where(h => h.IsSuccess)
                .Select(h => (double)h.ResponseMillis)
                .DefaultIfEmpty(0)
                .Average();
        }
    }

    // Тема LINQ: Фильтруем ошибки и сортируем (сначала новые)
    public IEnumerable<ServicePingResult> GetFailureReports()
    {
        lock (_lock)
        {
            return _history
                .Where(h => !h.IsSuccess)
                .OrderByDescending(h => h.CheckedAt)
                .ToList();
        }
    }
}
