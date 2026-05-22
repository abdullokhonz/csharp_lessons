namespace FinanceTracker
{
    public class App
    {
        public async Task RunAsync()
        {
            Menu();
        }

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== МЕНЕДЖЕР ЛИЧНЫХ ФИНАНСОВ ===");
                Console.WriteLine("1. Показать все транзакции");
                Console.WriteLine("2. Добавить транзакцию");
                Console.WriteLine("3. Загрузить курсы валют (Сеть)");
                Console.WriteLine("4. Показать общий баланс в USD");
                Console.WriteLine("5. Запустить фоновую загрузку архивов (Тест отмены)");
                Console.WriteLine("6. Выход");
                Console.Write("\nВыберите действие: ");

                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            // Вызов метода показа
                            break;
                        case "2":
                            // Вызов метода добавления
                            break;
                        case "3":
                            // await ЗагрузкаКурсовAsync(...);
                            break;
                        case "4":
                            // Подсчет баланса
                            break;
                        case "5":
                            // Тест CancellationToken
                            break;
                        case "6":
                            Console.WriteLine("До свидания!");
                            return;
                        default:
                            Console.WriteLine("Неверный пункт меню. Нажмите любую клавишу...");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ОШИБКА В МЕНЮ]: {ex.Message}");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}
