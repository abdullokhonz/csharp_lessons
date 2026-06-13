using Microsoft.AspNetCore.Mvc;
using SmartBanking.API.Entities;
using SmartBanking.API.Infrastructure.Data;
using SmartBanking.API.Models;

namespace SmartBanking.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly SmartBankingDbContext _context;

    public UsersController(SmartBankingDbContext context) => _context = context;

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        // Автоматическая валидация DataAnnotations благодаря [ApiController]
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var response = new UserResponse(user.Id, user.Name, user.Email, user.BonusBalance);
        return CreatedAtAction(nameof(Register), new { id = user.Id }, response);
    }
}
