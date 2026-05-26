namespace SmartDelivery.Models
{
    public record Order(
        Guid Id,
        string CustomerName,
        decimal Weight,
        string DestinationCountry,
        string? PromoCode
    );
}
