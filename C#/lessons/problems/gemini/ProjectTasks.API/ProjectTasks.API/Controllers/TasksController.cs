using Microsoft.AspNetCore.Mvc;
using ProjectTasks.API.DTOs;
using ProjectTasks.API.Entities;
using ProjectTasks.API.Services.Interfaces;

namespace ProjectTasks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController(ITaskService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ProjectTask>?>> GetAllTasks(CancellationToken ct)
    {
        var tasks = await service.GetTasks(ct);
        
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectTask>> CreateTask([FromBody] CreateTaskDto dto, CancellationToken ct)
    {
        var task = await service.CreateTask(dto, ct);
        
        return Ok(task);
    }

    [HttpPut("{id:int}")]
    public async Task<bool> Update([FromRoute] int id, CancellationToken ct)
    {
        await  service.UpdateTask(id, ct);
        
        return true;
    }

    [HttpDelete("{id:int}")]
    public async Task<bool> DeleteTask([FromRoute] int id, CancellationToken ct)
    {
        await service.DeleteTask(id, ct);
        
        return true;
    }
}