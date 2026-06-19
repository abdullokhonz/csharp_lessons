using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Infrastructure.Data;
using ProductCatalog.API.Infrastructure.Middlewares;
using ProductCatalog.API.Infrastructure.Services;
using Scalar.AspNetCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);

// ТЕМА 4.1, 4.7: Настройка встроенного контейнера зависимостей (IoC Container)
builder.Services.AddControllers();

// Тема 4.7: Демонстрация времени жизни Scoped (создается один раз на каждый HTTP-запрос)
builder.Services.AddScoped<IDiagnosticService, DiagnosticService>();

// Тема 5.1: Конфигурация DbContext с провайдером PostgreSQL (Регистрация как Scoped по умолчанию)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// ТЕМА 4.2: Настройка Конвейера Middleware (Middleware Pipeline)
// Важен порядок! Наш кастомный логгер замера скорости стоит в самом начале
app.UseMiddleware<PerformanceLogMiddleware>();

app.UseHttpsRedirection();

// Тема 4.3: Маппинг атрибутных маршрутов контроллеров
app.MapControllers();

app.Run();
