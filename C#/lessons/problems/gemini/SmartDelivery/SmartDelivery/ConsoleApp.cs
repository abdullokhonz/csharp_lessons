using SmartDelivery.Services.Interfaces;

namespace SmartDelivery;

public class ConsoleApp
{
    private readonly IOrderService _orderService;

    public ConsoleApp(IOrderService orderService)
    {
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    public async Task Run()
    {
        while (true)
        {
            DisplayMenu();
            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1": RegisterNewOrder(); break;
                    case "2": ShowAllOrders(); break;
                    case "3": await LoadCurrencyRates(); break;
                    case "4": CalculateTotalCost(); break; // Заполнено
                    case "5": await SendNotificationsWithTimeout(); break; // Заполнено
                    case "6": ExitApplication(); break;
                    default: Console.WriteLine("Неверный пункт меню."); break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Произошла ошибка: {0}", ex.Message);
                Console.ResetColor();
            }

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    private static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n=== Система умной доставки ===");
        Console.ResetColor();
        Console.WriteLine("1. Зарегистрировать новый заказ");
        Console.WriteLine("2. Показать все заказы (Сортировка по весу)");
        Console.WriteLine("3. Загрузить курсы валют (Сеть/API)");
        Console.WriteLine("4. Рассчитать стоимость всех доставок в EUR");
        Console.WriteLine("5. Массовая отправка СМС-уведомлений (Тест отмены)");
        Console.WriteLine("6. Выход");
        Console.Write("\nВыберите действие (1-6): ");
    }

    private void RegisterNewOrder()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n=== Регистрация нового заказа ===");
        Console.ResetColor();

        Console.Write("Введите имя клиента: ");
        string? customerName = Console.ReadLine();

        Console.Write("Введите код валюты страны назначения (например, USD, RUB, EUR): ");
        string? currencyCode = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(currencyCode)) currencyCode = "EUR";

        Console.Write("Введите вес посылки (кг): ");
        // Тема 1: Валидация ввода без использования тяжелых исключений через TryParse
        if (!decimal.TryParse(Console.ReadLine(), out decimal weight) || weight <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Некорректный ввод веса. Пожалуйста, введите положительное число.");
            Console.ResetColor();
            return;
        }

        Console.Write("Введите промокод (можно пропустить): ");
        string? promoCode = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(promoCode)) promoCode = null;

        _orderService.AddOrder(customerName!, weight, currencyCode, promoCode);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Заказ успешно зарегистрирован!");
        Console.ResetColor();
    }

    private void ShowAllOrders()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n=== Все заказы (Сортировка по весу) ===");
        Console.ResetColor();

        var orders = _orderService.GetAllOrders();

        // Тема 5: LINQ Any()
        if (!orders.Any())
        {
            Console.WriteLine("Нет зарегистрированных заказов.");
            return;
        }

        foreach (var order in orders)
        {
            Console.WriteLine($"- Клиент: {order.CustomerName}, Вес: {order.Weight} кг, Направление: {order.DestinationCountry}, Промокод: {order.PromoCode}");
        }
    }

    private async Task LoadCurrencyRates()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n=== Загрузка курсов валют ===");
        Console.ResetColor();

        await _orderService.SetRatesAsync(CancellationToken.None);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Курсы валют успешно загружены с внешнего API!");
        Console.ResetColor();
    }

    // Реализация пункта 4
    private void CalculateTotalCost()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n=== Расчет стоимости всех доставок ===");
        Console.ResetColor();

        decimal total = _orderService.CalculateTotalCostInEur();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Общая стоимость всех доставок логистической сети: {total:F2} EUR");
        Console.ResetColor();
    }

    // Реализация пункта 5 (Тест отмены)
    private async Task SendNotificationsWithTimeout()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n=== Массовая отправка уведомлений ===");
        Console.ResetColor();

        // Тема 4: Настраиваем автоматический взрыв токена через 2.5 секунды
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2.5));

        try
        {
            Console.WriteLine("Запуск отправки. Лимит времени выполнения операции: 2.5 секунды...");
            await _orderService.SimulateNotificationSendAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            // Тема 4: Мягко отлавливаем прерывание асинхронного таска
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[ВНИМАНИЕ]: Время выполнения истекло! Операция рассылки была экстренно прервана токеном отмены.");
            Console.ResetColor();
        }
    }

    private static void ExitApplication()
    {
        Console.WriteLine("Выход из системы...");
        Environment.Exit(0);
    }
}
