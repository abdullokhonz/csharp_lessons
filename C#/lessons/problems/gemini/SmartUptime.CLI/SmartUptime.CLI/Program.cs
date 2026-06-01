using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartUptime.CLI;
using SmartUptime.CLI.HttpClients.Inplementations;
using SmartUptime.CLI.HttpClients.Interfaces;
using SmartUptime.CLI.Services.Implementations;
using SmartUptime.CLI.Services.Interfaces;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        // Регистрируем HTTP-клиент
        services.AddHttpClient<ITestClient, TestClient>();

        // Регистрируем сервис мониторинга как Singleton (чтобы история хранилась между вызовами меню)
        services.AddSingleton<IUptimeMonitorService, UptimeMonitorService>();

        // Регистрируем класс приложения
        services.AddTransient<App>();
    })
    .Build();

var app = host.Services.GetRequiredService<App>();
await app.Run();
