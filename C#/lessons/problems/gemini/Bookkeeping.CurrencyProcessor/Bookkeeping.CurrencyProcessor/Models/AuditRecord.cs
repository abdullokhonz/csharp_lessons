namespace Bookkeeping.CurrencyProcessor.Models
{
    record AuditRecord(
        Guid Id,
        DateTimeOffset Timestamp,
        string Message
    );
}
