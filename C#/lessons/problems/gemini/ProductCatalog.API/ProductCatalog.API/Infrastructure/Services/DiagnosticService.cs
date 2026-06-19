namespace ProductCatalog.API.Infrastructure.Services
{
    public class DiagnosticService : IDiagnosticService
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
    }
}
