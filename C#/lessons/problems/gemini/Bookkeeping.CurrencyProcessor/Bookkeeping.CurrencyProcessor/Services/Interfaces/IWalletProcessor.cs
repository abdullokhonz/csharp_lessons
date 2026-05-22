using Bookkeeping.CurrencyProcessor.Models;

namespace Bookkeeping.CurrencyProcessor.Services.Interfaces
{
    public interface IWalletProcessor
    {
        Task ProcessWalletsAsync(IEnumerable<Wallet> wallets, CancellationToken ct);
    }
}
