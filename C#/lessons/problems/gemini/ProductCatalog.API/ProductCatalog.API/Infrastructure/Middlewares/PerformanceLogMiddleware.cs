using ProductCatalog.API.Infrastructure.Services;
using System.Diagnostics;

namespace ProductCatalog.API.Infrastructure.Middlewares
{
    // Тема 4.2: Кастомный Middleware для профилирования скорости работы API
    public class PerformanceLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PerformanceLogMiddleware> _logger;

        public PerformanceLogMiddleware(RequestDelegate _next, ILogger<PerformanceLogMiddleware> logger)
        {
            this._next = _next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IDiagnosticService diagnostic)
        {
            var stopwatch = Stopwatch.StartNew();

            // Тема 4.7: Демонстрируем работу Scoped DI внутри конвейера Middleware
            _logger.LogInformation("Middleware поймал запрос. ID диагностики: {Id}", diagnostic.InstanceId);

            await _next(context); // Передаем запрос дальше по цепочке

            stopwatch.Stop();
            _logger.LogInformation("Запрос {Path} выполнен за {Ms} мс.", context.Request.Path, stopwatch.ElapsedMilliseconds);
        }
    }
}
