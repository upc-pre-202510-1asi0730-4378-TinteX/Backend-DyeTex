using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.ARM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Entities;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options) {
    
    public DbSet<TaskEntity> Tasks { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyMonitoringDataConfiguration();
        
        builder.ApplyConfiguration(new TaskEntityConfiguration());
        
        builder.UseSnakeCaseNamingConvention();
    }
}