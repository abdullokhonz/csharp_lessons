using ProjectTasks.API.Entities;
using ProjectTasks.API.Infrastructure.Data;
using ProjectTasks.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectTasks.API.DTOs;

namespace ProjectTasks.API.Services.Implementations;

public class TaskService(MyDbContext context, ILogger<TaskService> logger) : ITaskService
{
    private readonly MyDbContext _context = context;
    private readonly ILogger<TaskService> _logger = logger;
    
    public async Task<IEnumerable<ProjectTask>> GetTasks(CancellationToken ct = default)
    {
        _logger.LogInformation("Запрос на получение всех задач");

        return await _context.ProjectTasks
            .ToListAsync(ct);
    }

    public async Task<ProjectTask> CreateTask(CreateTaskDto dto, CancellationToken ct = default)
    {
        var task = new ProjectTask
        {
            Title = dto.Title,
            IsCompleted =  dto.IsCompleted,
            ProjectId =  dto.ProjectId,
        };
        
        await _context.ProjectTasks.AddAsync(task, ct);
        await _context.SaveChangesAsync(ct);
        
        return task;
    }

    public async Task<bool> UpdateTask(int id, CancellationToken ct = default)
    {
        var task = await _context.ProjectTasks.FirstOrDefaultAsync(t => t.Id == id, ct);

        if (task == null)
        {
            _logger.LogWarning("Задача с ID {Id} не найдена для обновления.", id);
            return false; 
        }
        
        task?.IsCompleted = true;
        await  _context.SaveChangesAsync(ct);
        
        return true;
    }

    public async Task<bool> DeleteTask(int id, CancellationToken ct = default)
    {
        var task = await _context.ProjectTasks.FirstOrDefaultAsync(t => t.Id == id, ct);

        if (task == null)
            return false;
        
        _context.ProjectTasks.Remove(task);
        await  _context.SaveChangesAsync(ct);
        
        return true;
    }
}