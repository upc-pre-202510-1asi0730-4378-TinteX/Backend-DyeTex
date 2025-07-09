using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;

namespace TinteX.DyeText.Platform.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMonitoringDataConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Notifications>().HasKey(n => n.Id);
        builder.Entity<Notifications>().Property(n => n.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notifications>().Property(n => n.Message).IsRequired().HasMaxLength(250);
        builder.Entity<Notifications>().Property(n => n.TextileMachine).IsRequired().HasMaxLength(50);
        builder.Entity<Notifications>().Property(n => n.MarkAsRead).IsRequired();
    }
}