namespace ProjectTasks.API.Entities;

public class Project
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}