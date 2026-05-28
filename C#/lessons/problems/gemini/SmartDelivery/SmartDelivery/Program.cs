using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartDelivery;
using SmartDelivery.HttpClients.Implementations;
using SmartDelivery.HttpClients.Interfaces;
using SmartDelivery.Services.Implementations;
using SmartDelivery.Services.Interfaces;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        // Тема 6: Настройка HttpClientFactory с таймаутом
        services.AddHttpClient<IExchangeRateClient, ExchangeRateClient>(client =>
        {
            client.BaseAddress = new Uri("https://open.er-api.com/v6/latest/");
            client.Timeout = TimeSpan.FromSeconds(3);
        });

        // Тема 2: Регистрируем сервис как Singleton, чтобы данные заказов не стирались в памяти
        services.AddSingleton<IOrderService, OrderService>();

        // Регистрируем само консольное приложение в DI-контейнере
        services.AddTransient<ConsoleApp>();
    })
    .Build();

// Тема 3: Извлекаем приложение со всеми готовыми зависимостями из DI
var app = host.Services.GetRequiredService<ConsoleApp>();
await app.Run();
