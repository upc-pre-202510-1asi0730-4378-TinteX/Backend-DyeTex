using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Configuration;

public class RequestInvoiceConfiguration : IEntityTypeConfiguration<RequestInvoice>
{
    public void Configure(EntityTypeBuilder<RequestInvoice> builder)
    {
        builder.ToTable("request_invoices");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasColumnName("request_invoice_id") 
            .HasConversion(id => id.Value, value => new(value))
            .ValueGeneratedNever();

        builder.OwnsOne(r => r.RequestId, ri =>
        {
            ri.Property(p => p.Value)
                .HasColumnName("request_id")
                .IsRequired();
        });


        builder.Property(r => r.TotalAmount)
            .IsRequired();

        builder.Property(r => r.IssueDate)
            .HasConversion(
                v => v.ToDateTime(TimeOnly.MinValue),  
                v => DateOnly.FromDateTime(v))        
            .HasColumnName("issue_date")
            .IsRequired();
    }
}