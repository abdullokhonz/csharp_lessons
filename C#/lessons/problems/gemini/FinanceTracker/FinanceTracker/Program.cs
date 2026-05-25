using FinanceTracker.Exceptions;
using FinanceTracker.HttpClients;
using FinanceTracker.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinanceTracker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Настраиваем стандартный хост .NET (DI контейнер, Логирование, HttpClientFactory)
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Тема 6: Регистрируем типизированный HttpClient с таймаутом в 3 секунды
                    services.AddHttpClient<IExchangeRateClient, ExchangeRateClient>(client =>
                    {
                        client.BaseAddress = new Uri("https://open.er-api.com/v6/latest/");
                        client.Timeout = TimeSpan.FromSeconds(3);
                    });

                    services.AddSingleton<IFinanceService, FinanceService>();
                })
                // Настраиваем консольный логгер, чтобы он не спамил системными логами
                /*.ConfigureLogging(logging =>
                {
                    // Microsoft.Extensions.Logging.Console
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Information); // Показываем только Info и выше
                })*/
                .Build();

            var service = host.Services.GetRequiredService<IFinanceService>();
            var client = host.Services.GetRequiredService<IExchangeRateClient>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== УМНЫЙ МЕНЕДЖЕР ЛИЧНЫХ ФИНАНСОВ ===");
                Console.ResetColor();
                Console.WriteLine("1. Показать все транзакции (Фильтрация от больших к меньшим)");
                Console.WriteLine("2. Добавить новую транзакцию");
                Console.WriteLine("3. Загрузить курсы валют из интернета (Сеть)");
                Console.WriteLine("4. Показать общий баланс в USD (LINQ расчет)");
                Console.WriteLine("5. Скачать тяжелый архив (Тест экстренной отмены за 2 сек)");
                Console.WriteLine("6. Выход");
                Console.Write("\nВыберите действие (1-6): ");

                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var txs = service.GetAllTransactions();
                            // Тема 5: LINQ Any() для быстрой проверки на пустоту коллекции
                            if (!txs.Any())
                            {
                                Console.WriteLine("Транзакций пока нет. Добавьте их через пункт 2.");
                                break;
                            }

                            Console.WriteLine("\nСписок ваших транзакций (Сортировка по убыванию суммы):");
                            // Тема 5: LINQ OrderByDescending для красивого вывода топ-трат
                            foreach (var t in txs.OrderByDescending(x => x.Amount))
                            {
                                Console.WriteLine($"- [{t.Category}] {t.Amount} {t.Currency} ({t.Comment})");
                            }
                            break;

                        case "2":
                            Console.Write("Введите категорию (например, Еда): ");
                            string? cat = Console.ReadLine();

                            Console.Write("Введите сумму: ");
                            string? amountInput = Console.ReadLine();

                            // Тема 1: Когда НЕ надо использовать исключения. 
                            // Вместо try-catch для валидации строки используем безопасный decimal.TryParse
                            if (!decimal.TryParse(amountInput, out decimal finalAmount))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка ввода! Сумма должна быть числом.");
                                Console.ResetColor();
                                break;
                            }

                            Console.Write("Введите валюту (USD, EUR, RUB): ");
                            string? curr = Console.ReadLine() ?? "USD";

                            Console.Write("Введите комментарий (можно пропустить): ");
                            string? comm = Console.ReadLine();

                            // Если строка пустая, запишем null для проверки оператора ??= внутри сервиса
                            if (string.IsNullOrWhiteSpace(comm)) comm = null;

                            // Вызываем метод сервиса (внутри могут сработать ArgumentNullException или NegativeAmountException)
                            service.AddTransaction(cat!, finalAmount, curr, comm);
                            break;

                        case "3":
                            // Тема 4: Асинхронный вызов HTTP-клиента
                            // Передаем CancellationToken.None, так как отмена из консоли тут не предусмотрена
                            var rates = await client.GetRatesAsync(CancellationToken.None);
                            service.SetRates(rates);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Курсы валют успешно обновлены! Теперь баланс в USD будет точным.");
                            Console.ResetColor();
                            break;

                        case "4":
                            decimal total = service.CalculateTotalBalanceInUsd();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nВаш общий баланс: {total:F2} USD");
                            Console.ResetColor();
                            break;

                        case "5":
                            // Тема 4: Тестируем CancellationToken. 
                            // Создаем пульт отмены, который автоматически "нажмет кнопку стоп" через 2 секунды
                            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2)))
                            {
                                Console.WriteLine("Запуск процесса. Он займет 5 секунд, но токен отменит его на 2-й секунде...");
                                await service.SimulateArchiveDownloadAsync(cts.Token);
                            }
                            break;

                        case "6":
                            Console.WriteLine("Программа завершена. До встречи!");
                            return;

                        default:
                            Console.WriteLine("Неверный формат ввода. Выберите цифру от 1 до 6.");
                            break;
                    }
                }
                // Тема 1: Отлавливаем наше кастомное исключение бизнеса
                catch (NegativeAmountException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[БИЗНЕС-ОШИБКА]: {ex.Message}");
                    Console.ResetColor();
                }
                // Тема 3: Ловим системный ArgumentNullException
                catch (ArgumentNullException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ОШИБКА ВАЛИДАЦИИ NULL]: {ex.Message}");
                    Console.ResetColor();
                }
                // Тема 4: Ловим прерывание асинхронного таска (Пункт 5 меню упадет сюда)
                catch (OperationCanceledException)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n[УВЕДОМЛЕНИЕ]: Тяжелая операция была экстренно прервана токеном CancellationToken!");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[НЕПРЕДВИДЕННАЯ ОШИБКА]: {ex.Message}");
                    Console.ResetColor();
                }

                Console.WriteLine("\nНажмите Enter для возврата в меню...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
