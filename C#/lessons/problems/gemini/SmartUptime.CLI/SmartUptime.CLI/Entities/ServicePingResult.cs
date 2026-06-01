namespace SmartUptime.CLI.Entities
{
    public record ServicePingResult(
        string ServiceName,
        bool IsSuccess,
        long ResponseMillis,
        string? ErrorMessage,
        DateTime CheckedAt
    );
}
