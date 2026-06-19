namespace ProductCatalog.API.Infrastructure.Services
{
    // Тема 4.7: Демонстрационный интерфейс для отслеживания Lifetimes
    public interface IDiagnosticService
    {
        Guid InstanceId { get; }
    }
}
