using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace TinteX.DyeText.Platform.Profiles.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProfilesConfiguration(this ModelBuilder builder)
    {
        // Configuración de Profile (ya existente)
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });

        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });

        // Configuración de AssignUser
        builder.Entity<AssignUser>().HasKey(a => a.Id);
        builder.Entity<AssignUser>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<AssignUser>().Property(a => a.Name).IsRequired();
        builder.Entity<AssignUser>().Property(a => a.Email).IsRequired();
        builder.Entity<AssignUser>().Property(a => a.Phone).IsRequired();
        builder.Entity<AssignUser>().Property(a => a.StartDate).IsRequired();
        builder.Entity<AssignUser>().Property(a => a.Plant).IsRequired();
        builder.Entity<AssignUser>().Property(a => a.Role).IsRequired();
        builder.Entity<AssignUser>().Property(a => a.Permission).IsRequired();
    }
}