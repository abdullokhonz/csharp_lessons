namespace SmartAvia.Models
{
    public record FlightBooking(
        Guid Id,
        string PassengerName,
        string FlightNumber,
        decimal BasePriceInUsd,
        string TargetCurrency,
        string? PassportNumber
    );
}
