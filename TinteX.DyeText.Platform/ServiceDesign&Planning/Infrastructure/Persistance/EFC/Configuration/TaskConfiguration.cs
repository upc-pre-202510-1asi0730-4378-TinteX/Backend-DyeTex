using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using Task = TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates.Task;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("tasks");
            builder.HasKey(t => t.Id);
            builder.Property<object>(t => t.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            builder.Property<object>(t => t.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
