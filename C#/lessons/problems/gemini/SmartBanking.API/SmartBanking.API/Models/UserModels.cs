using System.ComponentModel.DataAnnotations;

namespace SmartBanking.API.Models;

// DataAnnotations защищают входные данные
public record RegisterUserRequest(
    [Required(ErrorMessage = "Имя обязательно")] string Name,
    [Required, EmailAddress(ErrorMessage = "Неверный формат Email")] string Email
);

public record UserResponse(Guid Id, string Name, string Email, decimal BonusBalance);
