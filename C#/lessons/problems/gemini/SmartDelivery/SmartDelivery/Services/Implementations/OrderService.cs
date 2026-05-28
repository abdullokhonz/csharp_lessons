using Microsoft.Extensions.Logging;
using SmartDelivery.Exceptions;
using SmartDelivery.HttpClients.Interfaces;
using SmartDelivery.Models;
using SmartDelivery.Services.Interfaces;

namespace SmartDelivery.Services.Implementations;

public class OrderService : IOrderService
{
    private const decimal _baseRatePerKg = 5m;
    private readonly List<Order> _orders = new();
    private readonly HashSet<string> _uniqueCustomerNames = new();
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
        // Тема 3: Выброс ArgumentNullException при обнаружении null/empty
        if (string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentNullException(nameof(customerName), "Имя клиента не может быть пустым.");

        // Тема 1: Использование кастомного исключения для бизнес-ошибки
        if (weight <= 0)
            throw new InvalidWeightException("Вес заказа должен быть строго больше нуля.");

        // Тема 3: Оператор объединения с null ??=
        promoCode ??= "NO_PROMO";

        var order = new Order(
            Guid.NewGuid(),
            customerName.Trim(),
            weight,
            destinationCountry.ToUpper(),
            promoCode
        );

        _orders.Add(order);

        // Тема 2: ИспользованиеHashSet для уникальных клиентов
        if (_uniqueCustomerNames.Add(order.CustomerName))
        {
            _logger.LogInformation("Зарегистрирован совершенно новый клиент в базе: {CustomerName}", order.CustomerName);
        }

        // Тема 7: Структурное логирование
        _logger.LogInformation("Успешно добавлен новый заказ {OrderId} для {CustomerName}", order.Id, order.CustomerName);
    }

    // Тема 5: LINQ OrderBy
    public IEnumerable<Order> GetAllOrders() => _orders.OrderBy(o => o.Weight);

    public async Task SetRatesAsync(CancellationToken ct = default)
    {
        _rates = await _exchangeRateClient.GetExchangeRatesAsync(ct).ConfigureAwait(false);
    }

    public decimal CalculateTotalCostInEur()
    {
        if (!_orders.Any()) return 0;

        if (!_rates.Any())
        {
            // Тема 7: Уровень логирования Warning для неопасных аномалий
            _logger.LogWarning("Расчет неточен: курсы валют еще не были загружены из сети!");
        }

        // Тема 5: LINQ Sum
        return _orders.Sum(o =>
        {
            decimal costInLocal = o.Weight * _baseRatePerKg;

            if (o.DestinationCountry == "EUR") return costInLocal;

            // Тема 3: Безопасное извлечение из Dictionary
            if (_rates.TryGetValue(o.DestinationCountry, out var rate) && rate != 0)
            {
                // Исправлено: Переводим локальную валюту в EUR (делением на рейт)
                return costInLocal / rate;
            }

            _logger.LogWarning("Не получилось рассчитать стоимость для валюты {Country}. Курс подменен на 0.", o.DestinationCountry);
            return 0;
        });
    }

    public async Task SimulateNotificationSendAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("Начинаем отправку уведомлений клиентам...");

        foreach (var order in _orders)
        {
            // Тема 4: Ручной контроль токена отмены перед каждым шагом
            ct.ThrowIfCancellationRequested();

            // Симуляция отправки (Каждая итерация занимает 1 секунду)
            await Task.Delay(1000, ct).ConfigureAwait(false);

            _logger.LogInformation("Уведомление успешно отправлено клиенту {CustomerName} для заказа {OrderId}.", order.CustomerName, order.Id);
        }

        _logger.LogInformation("Завершена отправка уведомлений клиентам.");
    }
}
