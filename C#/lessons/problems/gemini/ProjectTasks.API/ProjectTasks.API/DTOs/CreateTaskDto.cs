using System.ComponentModel.DataAnnotations;

namespace ProjectTasks.API.DTOs;

public record CreateTaskDto(
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    string Title,
    
    bool IsCompleted,
    Guid ProjectId
);