using SmartUptime.CLI.Services.Interfaces;

namespace SmartUptime.CLI;

public class App
{
    private readonly IUptimeMonitorService _monitorService;

    public App(IUptimeMonitorService monitorService)
    {
        _monitorService = monitorService ?? throw new ArgumentNullException(nameof(monitorService));
    }

    public async Task Run()
    {
        while (true)
        {
            ShowMenu();
            string? input = Console.ReadLine();
            Console.Clear();

            try
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Опрашиваем серверы...");
                        await _monitorService.RunMetricsCheckAsync(CancellationToken.None);
                        break;

                    case "2":
                        ShowStatistics();
                        break;

                    case "3":
                        ShowFailures();
                        break;

                    case "4":
                        await SimulateEmergencyCancellation();
                        break;

                    case "5":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Мониторинг завершен. До свидания!");
                        Console.ResetColor();
                        return;

                    default:
                        Console.WriteLine("Неверный ввод. Выберите пункт от 1 до 5.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    private static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== SmartUptime: Система мониторинга API ===");
        Console.ResetColor();
        Console.WriteLine("1. Запустить параллельный опрос серверов");
        Console.WriteLine("2. Показать статистику доступности (LINQ)");
        Console.WriteLine("3. Показать журнал аварий и сбоев");
        Console.WriteLine("4. Тест экстренной отмены (CancellationToken)");
        Console.WriteLine("5. Выход");
        Console.Write("\nВыберите действие (1-5): ");
    }

    private void ShowStatistics()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== Статистика доступности серверов ===");
        Console.ResetColor();

        var history = _monitorService.GetHistory();
        if (!history.Any())
        {
            Console.WriteLine("История проверок пуста. Запустите опрос (Пункт 1).");
            return;
        }

        double avgTime = _monitorService.GetAverageResponseTime();
        int totalChecks = history.Count();
        int successChecks = history.Count(h => h.IsSuccess);

        Console.WriteLine($"Всего выполнено одиночных пингов: {totalChecks}");
        Console.WriteLine($"Успешно: {successChecks} | Сбоев: {totalChecks - successChecks}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Среднее время ответа живых служб: {avgTime:F2} мс");
        Console.ResetColor();
    }

    private void ShowFailures()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("=== Журнал аварий и сбоев ===");
        Console.ResetColor();

        var failures = _monitorService.GetFailureReports();
        if (!failures.Any())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("В журнале нет записей о сбоях. Все системы работают стабильно!");
            Console.ResetColor();
            return;
        }

        foreach (var fail in failures)
        {
            Console.WriteLine($"[{fail.CheckedAt:HH:mm:ss}] Сервис: {fail.ServiceName} | Время: {fail.ResponseMillis}мс | Ошибка: {fail.ErrorMessage}");
        }
    }

    private async Task SimulateEmergencyCancellation()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=== Симуляция мгновенного прерывания операции ===");
        Console.ResetColor();

        // Токен, который автоматически отменится через 5 миллисекунд (запрос гарантированно не успеет пройти)
        using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(5));

        try
        {
            Console.WriteLine("Запуск опроса с жестким лимитом в 5 мс...");
            await _monitorService.RunMetricsCheckAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ОТМЕНА]: Операция была успешно прервана токеном отмены!");
            Console.ResetColor();
        }
    }
}
