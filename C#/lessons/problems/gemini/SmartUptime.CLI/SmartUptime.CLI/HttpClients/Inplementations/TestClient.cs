using Microsoft.Extensions.Logging;
using SmartUptime.CLI.Entities;
using SmartUptime.CLI.HttpClients.Interfaces;
using System.Net.Http.Json;

namespace SmartUptime.CLI.HttpClients.Inplementations;

public class TestClient : ITestClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<TestClient> _logger;

    public TestClient(HttpClient httpClient, ILogger<TestClient> logger)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        _httpClient.Timeout = TimeSpan.FromSeconds(2.5); // ТЗ на таймаут
    }

    public async Task<IEnumerable<int>> GetUsersAsync(CancellationToken ct = default)
    {
        return await ExecuteGetRequestAsync("users", ct).ConfigureAwait(false);
    }

    public async Task<IEnumerable<int>> GetPostsAsync(CancellationToken ct = default)
    {
        return await ExecuteGetRequestAsync("posts", ct).ConfigureAwait(false);
    }

    public async Task<IEnumerable<int>> GetCommentsAsync(CancellationToken ct = default)
    {
        return await ExecuteGetRequestAsync("comments", ct).ConfigureAwait(false);
    }

    // DRY: Вынесли повторяющийся код запросов в один приватный метод
    private async Task<IEnumerable<int>> ExecuteGetRequestAsync(string endpoint, CancellationToken ct)
    {
        _logger.LogDebug("Отправка запроса к эндпоинту: {Endpoint}", endpoint);

        try
        {
            var response = await _httpClient.GetAsync(endpoint, ct).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var data = await response.Content
                .ReadFromJsonAsync<List<PingResponse>>(cancellationToken: ct)
                .ConfigureAwait(false);

            return data?.Select(u => u.Id) ?? Enumerable.Empty<int>();
        }
        catch (OperationCanceledException ex) when (!ct.IsCancellationRequested)
        {
            // Этот блок поймает таймаут HttpClient-а (2.5 секунды истекли)
            _logger.LogError(ex, "Превышено время ожидания (Таймаут 2.5с) для эндпоинта {Endpoint}", endpoint);
            throw new TimeoutException($"Сервер не ответил за отведенное время на запросе к {endpoint}", ex);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Сетевая ошибка HTTP при обращении к {Endpoint}", endpoint);
            throw;
        }
    }
}
