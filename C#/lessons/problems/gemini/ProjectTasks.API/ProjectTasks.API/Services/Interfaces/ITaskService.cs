using ProjectTasks.API.DTOs;
using ProjectTasks.API.Entities;

namespace ProjectTasks.API.Services.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<ProjectTask>> GetTasks(CancellationToken ct = default);
    
    Task<ProjectTask> CreateTask(CreateTaskDto dto, CancellationToken ct = default);
    
    Task<bool> UpdateTask(int id, CancellationToken ct = default);
    
    Task<bool> DeleteTask(int id, CancellationToken ct = default);
}