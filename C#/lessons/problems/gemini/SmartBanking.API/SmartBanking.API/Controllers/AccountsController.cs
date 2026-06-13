using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBanking.API.Infrastructure.Data;
using SmartBanking.API.Models;
using SmartBanking.API.Services;

namespace SmartBanking.API.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly SmartBankingDbContext _context;
    private readonly ITransferService _transferService;

    public AccountsController(SmartBankingDbContext context, ITransferService transferService)
    {
        _context = context;
        _transferService = transferService;
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActiveAccounts([FromQuery] decimal minBalance = 0)
    {
        // Ультимативная оптимизация LINQ: AsNoTracking + Select (вытаскиваем только нужные поля)
        var accounts = await _context.Accounts
            .AsNoTracking()
            .Where(a => a.IsActive && a.Balance >= minBalance)
            .Select(a => new ActiveAccountDto(a.Id, a.AccountNumber, a.Balance))
            .ToListAsync();

        return Ok(accounts);
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
    {
        var result = await _transferService.TransferAsync(request.FromAccountId, request.ToAccountId, request.Amount);
        return result ? Ok(new { Message = "Успешно" }) : BadRequest("Ошибка перевода");
    }
}
