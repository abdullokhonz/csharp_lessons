using System.ComponentModel.DataAnnotations;

namespace SmartBanking.API.Models;

public record TransferRequest(
    [Required] Guid FromAccountId,
    [Required] Guid ToAccountId,
    [Required, Range(0.01, 1000000, ErrorMessage = "Сумма перевода должна быть больше нуля")] decimal Amount
);

public record ActiveAccountDto(Guid Id, string AccountNumber, decimal Balance);
