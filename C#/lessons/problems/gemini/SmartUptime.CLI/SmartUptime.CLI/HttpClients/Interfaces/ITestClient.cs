using SmartUptime.CLI.Entities;

namespace SmartUptime.CLI.HttpClients.Interfaces
{
    public interface ITestClient
    {
        Task<IEnumerable<int>> GetUsersAsync(CancellationToken ct = default);

        Task<IEnumerable<int>> GetPostsAsync(CancellationToken ct = default);

        Task<IEnumerable<int>> GetCommentsAsync(CancellationToken ct = default);
    }
}
