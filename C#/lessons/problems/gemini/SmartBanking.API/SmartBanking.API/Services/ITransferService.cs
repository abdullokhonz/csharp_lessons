namespace SmartBanking.API.Services;

public interface ITransferService
{
    Task<bool> TransferAsync(Guid fromId, Guid toId, decimal amount);
}
