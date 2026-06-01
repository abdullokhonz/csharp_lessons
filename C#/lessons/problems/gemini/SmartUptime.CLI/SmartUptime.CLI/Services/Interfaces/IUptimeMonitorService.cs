using SmartUptime.CLI.Entities;

namespace SmartUptime.CLI.Services.Interfaces
{
    public interface IUptimeMonitorService
    {
        Task RunMetricsCheckAsync(CancellationToken ct = default);

        IEnumerable<ServicePingResult> GetHistory();

        double GetAverageResponseTime();

        IEnumerable<ServicePingResult> GetFailureReports();
    }
}
