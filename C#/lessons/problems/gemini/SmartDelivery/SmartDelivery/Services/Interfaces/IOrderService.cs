using SmartDelivery.Models;

namespace SmartDelivery.Services.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(string CustomerName, decimal Weight, string DestinationCountry, string? PromoCode = null);

        IEnumerable<Order> GetAllOrders();

        Task SetRatesAsync(CancellationToken ct = default);

        decimal CalculateTotalCostInEur();

        Task SimulateNotificationSendAsync(CancellationToken ct = default);
    }
}
