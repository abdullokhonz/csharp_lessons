using SmartAvia.Services;

namespace SmartAvia
{
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

                try
                {
                    switch (input)
                    {
                        case "1": break;
                        case "2": break;
                        case "3": break;
                        case "4": break;
                        case "5": break;
                        case "6": break;
                        default: break;
                    }

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        private static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Умная система бронирования авиабилетов ===");
            Console.ResetColor();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить бронирование рейса");
            Console.WriteLine("2. Показать все бронирования");
            Console.WriteLine("3. Загрузить курсы валют");
            Console.WriteLine("4. Показать общую сумму в целевой валюте");
            Console.WriteLine("5. Выпустить билеты");
            Console.WriteLine("6. Выйти");
            Console.WriteLine("Выберите действие (1-6): ");
        }
    }
}
