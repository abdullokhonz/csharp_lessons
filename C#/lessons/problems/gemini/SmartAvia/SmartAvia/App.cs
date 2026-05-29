using SmartAvia.Services;

namespace SmartAvia;

public class App
{
    private readonly IBookingService _bookingService;

    public App(IBookingService bookingService)
    {
        _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
    }

    public async Task Run()
    {
        while (true)
        {
            Menu();
            string? input = Console.ReadLine();
            Console.Clear();

            try
            {
                switch (input)
                {
                    case "1":
                        BookFlight();
                        break;
                    case "2":
                        ShowAllBookings();
                        break;
                    case "3":
                        await LoadExchangeRates();
                        break;
                    case "4":
                        ShowTotalFinancialReport();
                        break;
                    case "5":
                        await EmitTicketsWithTimeout();
                        break;
                    case "6":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Спасибо за использование SmartAvia! До свидания.");
                        Console.ResetColor();
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Выберите пункт от 1 до 6.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка в обработке меню: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    private static void Menu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== Умная система бронирования авиабилетов ===");
        Console.ResetColor();
        Console.WriteLine("1. Добавить бронирование рейса");
        Console.WriteLine("2. Показать все бронирования");
        Console.WriteLine("3. Загрузить курсы валют (Сеть)");
        Console.WriteLine("4. Показать общую сумму в целевой валюте");
        Console.WriteLine("5. Выпустить билеты (Тест отмены за 3 сек)");
        Console.WriteLine("6. Выйти");
        Console.Write("\nВыберите действие (1-6): ");
    }

    // Пункт 1: Регистрация бронирования
    private void BookFlight()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=== Регистрация нового бронирования ===");
        Console.ResetColor();

        Console.Write("Введите имя пассажира: ");
        string? name = Console.ReadLine();

        Console.Write("Введите номер рейса (например, SU-213): ");
        string? flightNum = Console.ReadLine();

        Console.Write("Введите базовую цену билета (USD): ");
        // Тема 1: Использование TryParse для валидации строки БЕЗ try-catch
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: Цена должна быть числом!");
            Console.ResetColor();
            return;
        }

        Console.Write("Введите валюту для оплаты (USD, RUB, EUR): ");
        string? currency = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(currency)) currency = "USD";

        Console.Write("Введите номер паспорта (можно пропустить): ");
        string? passport = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(passport)) passport = null; // Передаем null для обработки через ??= в сервисе

        // Вызов метода бизнес-логики (может выбросить кастомный BookingValidationException)
        _bookingService.AddFlightBooking(name!, flightNum!, price, currency, passport);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Бронирование успешно создано!");
        Console.ResetColor();
    }

    // Пункт 2: Показ всех броней
    private void ShowAllBookings()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=== Список всех бронирований ===");
        Console.ResetColor();

        var bookings = _bookingService.GetFlightBookings();

        // Тема 5: Проверка через LINQ Any
        if (!bookings.Any())
        {
            Console.WriteLine("В системе пока нет ни одного бронирования.");
            return;
        }

        foreach (var b in bookings)
        {
            Console.WriteLine($"- Рейс: {b.FlightNumber} | Пассажир: {b.PassengerName} | Цена: {b.BasePriceInUsd} USD | Валюта оплаты: {b.TargetCurrency} | Паспорт: {b.PassportNumber}");
        }
    }

    // Пункт 3: Сетевая загрузка курсов
    private async Task LoadExchangeRates()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=== Загрузка актуальных курсов валют ===");
        Console.ResetColor();

        await _bookingService.LoadExchangeRatesAsync(CancellationToken.None);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Курсы валют успешно применены к системе!");
        Console.ResetColor();
    }

    // Пункт 4: Финансовый отчет
    private void ShowTotalFinancialReport()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=== Финансовый отчет системы ===");
        Console.ResetColor();

        decimal totalSum = _bookingService.GetTotalAmountInTargetCurrency();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Общая сумма сборов (в целевых валютах пассажиров): {totalSum:F2}");
        Console.ResetColor();
    }

    // Пункт 5: Выпуск билетов с ограничением по времени (CancellationToken)
    private async Task EmitTicketsWithTimeout()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=== Пакетный выпуск электронных билетов ===");
        Console.ResetColor();

        // Тема 4: Автоматическое прерывание операции ровно через 3 секунды
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        try
        {
            Console.WriteLine("Запуск генерации билетов... Лимит времени: 3 секунды.");
            await _bookingService.EmitTicketsAsync(cts.Token);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Все билеты успешно сгенерированы без задержек!");
            Console.ResetColor();
        }
        catch (OperationCanceledException)
        {
            // Перехватываем экстренную отмену таски
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[УВЕДОМЛЕНИЕ]: Процесс выпуска билетов прерван! Превышен лимит времени (3 сек).");
            Console.ResetColor();
        }
    }
}
