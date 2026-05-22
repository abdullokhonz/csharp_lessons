namespace Bookkeeping.CurrencyProcessor.Models
{
    public record Wallet(
        Guid Id,
        string User,
        decimal Balance,
        string Currency,
        string? Metadata
    );
}
