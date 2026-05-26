using SmartDelivery.Services.Interfaces;

namespace SmartDelivery
{
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
                        case "4": break;
                        case "5": break;
                        case "6": ExitApplication(); break;
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
            Console.WriteLine("Выберите действие:");
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

            Console.Write("Введите код валюты вашей страны: ");
            string? currencyCode = Console.ReadLine() ?? "EUR";

            Console.Write("Введите вес посылки (кг): ");
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
            Console.WriteLine("Заказ успешно зарегистрирован для клиента {0}!", customerName);
            Console.ResetColor();
        }

        private void ShowAllOrders()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n=== Все заказы (Сортировка по весу) ===");
            Console.ResetColor();
            var orders = _orderService.GetAllOrders();
            if (!orders.Any())
            {
                Console.WriteLine("Нет зарегистрированных заказов.");
                return;
            }

            Console.WriteLine("Список всех заказов (Сортировка по весу):");

            foreach (var order in orders)
            {
                Console.WriteLine("Клиент: {0}, Вес: {1} кг, Валюта: {2}, Промокод: {3}",
                    order.CustomerName, order.Weight, order.DestinationCountry, order.PromoCode ?? "Нет");
            }
        }

        private async Task LoadCurrencyRates()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n=== Загрузка курсов валют ===");
            Console.ResetColor();
            try
            {
                await _orderService.SetRatesAsync();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Курсы валют успешно загружены!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка при загрузке курсов валют: {0}", ex.Message);
                Console.ResetColor();
            }
        }

        private static void ExitApplication()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Спасибо за использование системы умной доставки! До свидания!");
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
