using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTasks.API.Entities;

namespace ProjectTasks.API.Infrastructure.Configurations;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasOne(p => p.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(p => p.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}