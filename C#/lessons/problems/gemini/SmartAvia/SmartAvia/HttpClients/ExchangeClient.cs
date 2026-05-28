using Microsoft.Extensions.Logging;
using SmartAvia.Models;
using System.Net.Http.Json;

namespace SmartAvia.HttpClients
{
    public class ExchangeClient : IExchangeClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ExchangeClient> _logger;

        public ExchangeClient(HttpClient httpClient, ILogger<ExchangeClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _httpClient.BaseAddress = new Uri("https://open.er-api.com/v6/latest/");
            _httpClient.Timeout = TimeSpan.FromSeconds(4);
        }

        public async Task<Dictionary<string, decimal>> GetExchangeRatesAsync(CancellationToken ct = default)
        {
            _logger.LogInformation("Отправка запроса на сервис курсов валют.");

            try
            {
                var response = await _httpClient.GetAsync("USD", ct).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadFromJsonAsync<ApiResponse>(cancellationToken: ct).ConfigureAwait(false);

                var result = data?.Rates ?? new Dictionary<string, decimal>();

                _logger.LogInformation("Курсы валют успешно загружены.");

                return result;
            }
            catch (TimeoutException ex) when (!ct.IsCancellationRequested)
            {
                _logger.LogError(ex, "Время ожидания ответа сервера курсов валют истекло.");
                throw new TimeoutException("Сервер курсов валют не доступен.", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Произошла сетевая ошибка при получении курсов валют.");
                throw;
            }
        }
    }
}
