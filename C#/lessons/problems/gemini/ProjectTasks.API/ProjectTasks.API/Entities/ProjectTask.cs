namespace ProjectTasks.API.Entities;

public class ProjectTask
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; }
    
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}