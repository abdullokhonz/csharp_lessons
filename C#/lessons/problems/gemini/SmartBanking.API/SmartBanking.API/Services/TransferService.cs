using SmartBanking.API.Infrastructure.Data;
using SmartBanking.API.Services;

namespace SmartBanking.API.Services;

public class TransferService : ITransferService
{
    private readonly SmartBankingDbContext _context;
    private readonly ILogger<TransferService> _logger;

    public TransferService(SmartBankingDbContext context, ILogger<TransferService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> TransferAsync(Guid fromId, Guid toId, decimal amount)
    {
        // Открываем явную транзакцию
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var accountFrom = await _context.Accounts.FindAsync(fromId);
            var accountTo = await _context.Accounts.FindAsync(toId);

            if (accountFrom == null || accountTo == null || accountFrom.Balance < amount || !accountFrom.IsActive || !accountTo.IsActive)
            {
                _logger.LogWarning("Перевод отклонен: Некорректные счета или недостаточно средств. From: {FromId}, Amount: {Amount}", fromId, amount);
                return false;
            }

            // Логика списания/начисления
            accountFrom.Balance -= amount;
            accountTo.Balance += amount;

            // Начисление кэшбека 1% владельцу счета А
            var userFrom = await _context.Users.FindAsync(accountFrom.UserId);
            if (userFrom != null)
            {
                userFrom.BonusBalance += amount * 0.01m;
            }

            await _context.SaveChangesAsync();

            // ТЕСТ НА СТРЕСС/ОТКАТ: Раскомментируй строку ниже, чтобы проверить Rollback
            // throw new InvalidOperationException("Искусственный сбой сервера перед коммитом!");

            await transaction.CommitAsync();

            // Структурный лог уровня Information
            _logger.LogInformation("Перевод на сумму {Amount} со счета {From} на счет {To} выполнен успешно", amount, accountFrom.AccountNumber, accountTo.AccountNumber);
            return true;
        }
        catch (Exception ex)
        {
            // Если что-то пошло не так, база данных вернет всё в исходное состояние
            await transaction.RollbackAsync();
            // Структурный лог уровня Error
            _logger.LogError(ex, "Критическая ошибка при переводе денег между счетами {From} и {To}", fromId, toId);
            throw;
        }
    }
}
