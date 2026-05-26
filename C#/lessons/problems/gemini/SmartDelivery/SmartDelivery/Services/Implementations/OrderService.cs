using Microsoft.Extensions.Logging;
using SmartDelivery.Exceptions;
using SmartDelivery.HttpClients.Interfaces;
using SmartDelivery.Models;
using SmartDelivery.Services.Interfaces;

namespace SmartDelivery.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private const decimal _baseRatePerKg = 5m;
        private readonly List<Order> _orders = new();
        private readonly HashSet<string> _uniqueCustomerNames = new HashSet<string>();
        private Dictionary<string, decimal> _rates = new();
        private readonly IExchangeRateClient _exchangeRateClient;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IExchangeRateClient exchangeRateClient, ILogger<OrderService> logger)
        {
            _exchangeRateClient = exchangeRateClient ?? throw new ArgumentNullException(nameof(exchangeRateClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddOrder(string customerName, decimal weight, string destinationCountry, string? promoCode = null)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentNullException(nameof(customerName), "Имя клиента не может быть пустым.");

            if (weight <= 0)
                throw new InvalidWeightException("Вес заказа должен быть строго больше нуля.");

            promoCode ??= "NO_PROMO";

            var order = new Order
            (
                Guid.NewGuid(),
                customerName.Trim(),
                weight,
                destinationCountry.ToUpper(),
                promoCode
            );

            _orders.Add(order);

            if (_uniqueCustomerNames.Add(customerName))
                _logger.LogInformation("Добавлен новый клиент: {CustomerName}", customerName);

            _logger.LogInformation("Успешно добавлен новый заказ: {OrderId}", order.Id);
        }

        public IEnumerable<Order> GetAllOrders() => _orders.OrderBy(o => o.Weight);

        public async Task SetRatesAsync(CancellationToken ct = default)
        {
            _rates = await _exchangeRateClient.GetExchangeRatesAsync(ct).ConfigureAwait(false);
        }

        public decimal CalculateTotalCostInEur()
        {
            if (!_rates.Any())
                return 0;

            var result = _orders.Sum(o =>
            {
                if (o.DestinationCountry == "EUR") return o.Weight * _baseRatePerKg;

                if (_rates.TryGetValue(o.DestinationCountry, out var rate) && rate != 0)
                    return o.Weight * rate / _baseRatePerKg;

                _logger.LogInformation("Не получилось рассчитать стоимость для валюты {Country}", o.DestinationCountry);
                return 0;
            });

           return result;
        }

        public async Task SimulateNotificationSendAsync(CancellationToken ct = default)
        {
            _logger.LogInformation("Начинаем отправку уведомлений клиентам...");

            foreach (var order in _orders)
            {
                if (ct.IsCancellationRequested)
                {
                    _logger.LogWarning("Отправка уведомлений была отменена.");
                    break;
                }

                // Симуляция отправки уведомления (например, через email или SMS)
                await Task.Delay(1000, ct).ConfigureAwait(false); // Имитируем задержку отправки

                _logger.LogInformation("Уведомление успешно отправлено клиенту {CustomerName} для заказа {OrderId}.", order.CustomerName, order.Id);
            }

            _logger.LogInformation("Завершена отправка уведомлений клиентам.");
        }
    }
}
