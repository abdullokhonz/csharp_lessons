using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartAvia;
using SmartAvia.HttpClients;
using SmartAvia.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddHttpClient<IExchangeClient, ExchangeClient>();

        services.AddSingleton<IBookingService, BookingService>();

        services.AddTransient<App>();
    })
    .Build();

var app = host.Services.GetRequiredService<App>();

await app.Run();
