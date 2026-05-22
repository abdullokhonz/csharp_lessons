using Bookkeeping.CurrencyProcessor.Exceptions;
using Bookkeeping.CurrencyProcessor.HttpClients.Interfaces;
using Bookkeeping.CurrencyProcessor.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Bookkeeping.CurrencyProcessor.HttpClients.Implementations
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

        public async Task<Dictionary<string, decimal>> GetLatestRatesAsync(CancellationToken ct)
        {
            _logger.LogInformation("Запрос актуальных курсов валют к внешнему API...");

            try
            {
                // Корректный эндпоинт для open.er-api.com — v6/latest/USD
                var response = await _httpClient.GetAsync("USD", ct).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);

                // Тема 3: Работа с null (используем ??= для подстраховки)
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var currencyRateResponse = JsonSerializer.Deserialize<CurrencyRateResponse>(content, options);

                currencyRateResponse ??= new CurrencyRateResponse();

                if (currencyRateResponse.Rates == null)
                {
                    throw new CurrencyIntegrationException("API вернул пустой справочник курсов.");
                }

                _logger.LogDebug("Курсы валют успешно загружены. Всего валют: {Count}", currencyRateResponse.Rates.Count);
                return currencyRateResponse.Rates;
            }
            // Тема 6: Отличие таймаута HttpClient от ручной отмены CancellationToken
            catch (TaskCanceledException ex) when (!ct.IsCancellationRequested)
            {
                _logger.LogError(ex, "Внешний сервер не ответил вовремя (Таймаут HttpClient).");
                throw new CurrencyIntegrationException("Превышено время ожидания ответа от сервера курсов.", ex);
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogWarning("Операция получения курсов была отменена пользователем.");
                throw; // Пробрасываем дальше для корректной остановки хоста
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Сетевая ошибка HTTP при запросе курсов валют.");
                throw new CurrencyIntegrationException("Ошибка сетевого взаимодействия с API курсов.", ex);
            }
        }
    }
}
