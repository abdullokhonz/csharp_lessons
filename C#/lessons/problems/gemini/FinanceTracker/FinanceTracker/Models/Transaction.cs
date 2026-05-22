namespace FinanceTracker.Models
{
    public record Transaction(
        Guid Id,
        string Category,
        decimal Amount,
        string Currency,
        string? Comment
    );
}
