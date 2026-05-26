using Microsoft.Extensions.Logging;
using SmartDelivery.HttpClients.Interfaces;
using SmartDelivery.Models;
using System.Net.Http.Json;

namespace SmartDelivery.HttpClients.Implementations
{
    public class ExchangeRateClient : IExchangeRateClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ExchangeRateClient> _logger;

        public ExchangeRateClient(HttpClient httpClient, ILogger<ExchangeRateClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _httpClient.BaseAddress = new Uri("https://open.er-api.com/v6/latest/");
            _httpClient.Timeout = TimeSpan.FromSeconds(3);
        }

        public async Task<Dictionary<string, decimal>> GetExchangeRatesAsync(CancellationToken ct)
        {
            _logger.LogInformation("Fetching exchange rates from API.");

            try
            {
                var response = await _httpClient.GetAsync("EUR", ct).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadFromJsonAsync<ExchangeRateResponse>(cancellationToken: ct).ConfigureAwait(false);

                return data?.Rates ?? new Dictionary<string, decimal>();
            }
            catch (TaskCanceledException ex) when (!ct.IsCancellationRequested)
            {
                _logger.LogError(ex, "Время ожидания истекло при получении курсов обмена.");
                throw new TimeoutException("Сервер курсов валют не доступен.", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Сетевая ошибка при получении курсов обмена.");
                throw;
            }
        }
    }
}
