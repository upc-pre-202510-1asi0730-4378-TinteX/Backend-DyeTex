using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
// ARM
using TinteX.DyeText.Platform.ARM.Infrastructure.Persistence.EFC.Configuration.Extensions;

// Service Design
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Configuration;

// Shared
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

// Analytics
using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;

// Monitoring
using TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;

// Profiles
using TinteX.DyeText.Platform.Profiles.Infrastructure.Persistence.EFC.Configuration.Extensions;
using TinteX.DyeText.Platform.SAP.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    
    public DbSet<MachineFailureCount> MachineFailureCounts { get; set; }
    public DbSet<MachineFailureRate> MachineFailureRates { get; set; }
    public DbSet<TaskDueStatusCount> TaskDueStatusCounts { get; set; }
    public DbSet<Notifications> Notifications { get; set; }
    public DbSet<AssignUser> AssignUsers { get; set; }
    public DbSet<PlanningTask> PlanningTasks { get; set; }
    public DbSet<Maintenance> Maintenances { get; set; }
    public DbSet<RequestInvoice> RequestInvoices { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // ARM mappings
        builder.ApplyArmDataConfiguration();

        // ServiceDesign Planning mappings
        builder.ApplyConfiguration(new PlanningTaskConfiguration());
        builder.ApplyConfiguration(new MaintenanceConfiguration());
        builder.ApplyConfiguration(new RequestInvoiceConfiguration());

        builder.ApplyProfilesConfiguration();
        
        builder.ApplyPaymentCardConfiguration();

        // Analytics mappings
        builder.Entity<MachineFailureCount>(entity =>
        {
            entity.ToTable("machine_failure_counts");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MachineId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.MachineName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Count).IsRequired();
        });

        builder.Entity<MachineFailureRate>(entity =>
        {
            entity.ToTable("machine_failure_rates");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MachineId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.MachineName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Rate).IsRequired();
        });
        builder.Entity<TaskDueStatusCount>(entity =>
        {
            entity.ToTable("task_due_status_counts");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.OverdueCount).IsRequired();
            entity.Property(e => e.UpcomingCount).IsRequired();
        });

        builder.UseSnakeCaseNamingConvention();
    }
}
