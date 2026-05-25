namespace FinanceTracker.Models
{
    public record Transaction(
        Guid Id,
        string Category,
        decimal Amount,
        string Currency,
        string? Comment
    );

    // Класс для десериализации ответа от API курсов
    public class ExchangeResponse
    {
        public string BaseCode { get; set; } = string.Empty;
        public Dictionary<string, decimal>? Rates { get; set; }
    }
}
