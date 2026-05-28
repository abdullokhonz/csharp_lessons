using SmartAvia.Models;

namespace SmartAvia.Services
{
    public interface IBookingService
    {
        void AddFlightBooking(
            string PassengerName,
            string FlightNumber,
            decimal BasePriceInUsd,
            string TargetCurrency,
            string? PassportNumber
        );

        IEnumerable<FlightBooking> GetFlightBookings();

        Task LoadExchangeRatesAsync(CancellationToken ct = default);

        decimal GetTotalAmountInTargetCurrency();

        Task EmitTicketsAsync(CancellationToken ct = default);
    }
}
