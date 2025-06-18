using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;

namespace TinteX.DyeText.Platform.ARM.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyArmDataConfiguration(this ModelBuilder builder)
    {
        builder.Entity<TextileMachine>().HasKey(tm => tm.Id);
        builder.Entity<TextileMachine>().Property(tm => tm.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TextileMachine>().Property(tm => tm.MachineInformationId).IsRequired();
        builder.Entity<TextileMachine>().Property(tm => tm.Name).IsRequired().HasMaxLength(50);
        builder.Entity<TextileMachine>().Property(tm => tm.AssetType).IsRequired().HasMaxLength(30);
        builder.Entity<TextileMachine>().Property(tm => tm.Status).IsRequired();
        builder.Entity<TextileMachine>().Property(tm => tm.SerialNumber).IsRequired().HasMaxLength(50);
        builder.Entity<TextileMachine>().Property(tm => tm.Floor).IsRequired();
        builder.Entity<TextileMachine>().Property(tm => tm.Zone).IsRequired();
        builder.Entity<TextileMachine>().Property(tm => tm.DateInstallation).IsRequired();
        
        builder.Entity<MachineInformation>().HasKey(mi => mi.Id);
        builder.Entity<MachineInformation>().Property(mi => mi.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MachineInformation>().Property(mi => mi.TimeSpent).IsRequired().HasMaxLength(30);
        builder.Entity<MachineInformation>().Property(mi => mi.DayProgress).IsRequired().HasMaxLength(30);
        builder.Entity<MachineInformation>().Property(mi => mi.FailureRate).IsRequired().HasMaxLength(30);
        builder.Entity<MachineInformation>().Property(mi => mi.AmountFailure).IsRequired();
        
        builder.Entity<DeviceConfiguration>().HasKey(dc => dc.IpAddress);
        builder.Entity<DeviceConfiguration>().Property(dc => dc.ConnectionProtocol).IsRequired();
        builder.Entity<DeviceConfiguration>().Property(dc => dc.UpdateFrequency).IsRequired();

    }
    
}