using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;

namespace TinteX.DyeText.Platform.SAP.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyPaymentCardConfiguration(this ModelBuilder builder)
    {
        builder.Entity<PaymentCard>().HasKey(p => p.Id);
        builder.Entity<PaymentCard>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PaymentCard>().Property(p => p.UserName).IsRequired();
        builder.Entity<PaymentCard>().Property(p => p.Country).IsRequired();

        builder.Entity<PaymentCard>().OwnsOne(p => p.Card,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.NumberCard).HasColumnName("NumberCard").IsRequired();
                n.Property(p => p.ExpirationDate).HasColumnName("ExpirationDate");
                n.Property(p => p.CVV).HasColumnName("cvv");
            });
    }
}