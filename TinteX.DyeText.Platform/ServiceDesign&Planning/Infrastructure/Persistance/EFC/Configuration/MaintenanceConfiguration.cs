using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Configuration;

public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance> {
    public void Configure(EntityTypeBuilder<Maintenance> builder) {
        builder.ToTable("maintenances");
        
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .HasColumnName("maintenance_id") 
            .HasConversion(id => id.Value, value => new(value))
            .ValueGeneratedNever();

        builder.Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(m => m.ScheduledDate)
            .IsRequired();

        builder.Property(m => m.MachineId)
            .HasColumnName("machine_id")
            .IsRequired();


        builder.Property(m => m.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();
    }
}