using Microsoft.EntityFrameworkCore;
using ProjectTasks.API.Entities;

namespace ProjectTasks.API.Infrastructure.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Project> Tasks => Set<Project>();
    
    public DbSet<ProjectTask> ProjectTasks => Set<ProjectTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
    }
}