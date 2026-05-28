using SmartDelivery.Models;

namespace SmartDelivery.Services.Interfaces;

public interface IOrderService
{
    void AddOrder(string customerName, decimal weight, string destinationCountry, string? promoCode = null);
    IEnumerable<Order> GetAllOrders();
    Task SetRatesAsync(CancellationToken ct = default);
    decimal CalculateTotalCostInEur();
    Task SimulateNotificationSendAsync(CancellationToken ct = default);
}
