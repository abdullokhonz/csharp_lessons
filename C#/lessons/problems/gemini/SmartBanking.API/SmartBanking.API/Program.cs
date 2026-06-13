using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SmartBanking.API.Infrastructure.Data;
using SmartBanking.API.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Подключение базы данных (Scoped по умолчанию)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<SmartBankingDbContext>(options =>
    options.UseNpgsql(connectionString));

// 2. Регистрация сервисов с правильным временем жизни (Lifetimes)
builder.Services.AddScoped<ITransferService, TransferService>(); // Бизнес-логика (Scoped)
builder.Services.AddHostedService<BankMonitorWorker>();         // Фоновый воркер (Singleton)

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
