using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Entities;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Configuration;

public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity> {
    public void Configure(EntityTypeBuilder<TaskEntity> builder) {
        builder.ToTable("tasks"); 
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).IsRequired().HasMaxLength(255);
        builder.Property(t => t.DueDate).IsRequired().HasMaxLength(10);
    }
}