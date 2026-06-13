using Microsoft.EntityFrameworkCore;
using SmartBanking.API.Infrastructure.Data;

namespace SmartBanking.API.Services;

public class BankMonitorWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<BankMonitorWorker> _logger;

    public BankMonitorWorker(IServiceScopeFactory scopeFactory, ILogger<BankMonitorWorker> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Руками создаем временный Scope
            using (var scope = _scopeFactory.CreateScope())
            {
                // Безопасно достаем Scoped контекст базы данных внутри Singleton воркера
                var context = scope.ServiceProvider.GetRequiredService<SmartBankingDbContext>();

                // Считаем общую сумму всех денег в банке
                var totalBankBalance = await context.Accounts.AsNoTracking().SumAsync(a => a.Balance, stoppingToken);

                _logger.LogDebug("=== МОНИТОРИНГ БАНКА === Общий баланс всех счетов системы: {Total} USD", totalBankBalance);
            }

            // Спим 1 минуту
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
