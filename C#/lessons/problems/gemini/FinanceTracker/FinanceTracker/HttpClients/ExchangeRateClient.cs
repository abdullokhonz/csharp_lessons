using FinanceTracker.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace FinanceTracker.HttpClients
{
    public class ExchangeRateClient : IExchangeRateClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ExchangeRateClient> _logger;

        public ExchangeRateClient(HttpClient httpClient, ILogger<ExchangeRateClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Dictionary<string, decimal>> GetRatesAsync(CancellationToken ct)
        {
            // Тема 7: Структурный лог уровня Information (пульс системы)
            _logger.LogInformation("Запуск сетевого запроса к API курсов валют...");

            try
            {
                // Делаем асинхронный GET-запрос к API open.er-api.com
                // Тема 4: Используем ConfigureAwait(false) в библиотечном коде, где нет привязки к UI-потоку
                var response = await _httpClient.GetAsync("USD", ct).ConfigureAwait(false);

                // Тема 6: Обработка ошибок. Если статус-код не 2xx, метод сам выбросит HttpRequestException
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadFromJsonAsync<ExchangeResponse>(cancellationToken: ct).ConfigureAwait(false);

                // Тема 3: Работа с null. Используем null-coalescing (??) на случай, если Rates пришел пустым
                return data?.Rates ?? new Dictionary<string, decimal>();
            }
            // Тема 6: Ловим таймаут. Помним, что таймаут HttpClient вылетает как TaskCanceledException
            catch (TaskCanceledException ex) when (!ct.IsCancellationRequested)
            {
                _logger.LogError(ex, "Внешний сервер не ответил вовремя (Сработал таймаут HttpClient).");
                throw new TimeoutException("Сервер курсов валют недоступен.", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Сетевая ошибка HTTP при работе с API курсов.");
                throw;
            }
        }
    }
}
