using Flux.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flux.Infrastructure.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payments");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Currency).IsRequired().HasConversion<string>().HasMaxLength(3);
        builder.Property(p => p.Status).IsRequired().HasConversion<string>().HasMaxLength(20);
        builder.Property(p => p.IdempotencyKey).IsRequired().HasMaxLength(64);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Metadata).HasColumnType("jsonb");
        builder.Property(p => p.UpdatedAt).IsRequired();
        builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

        builder.HasIndex(p => p.IdempotencyKey).IsUnique();
        builder.HasIndex(p => p.MerchantId);
        builder.HasIndex(p => p.Status);

        builder
            .HasOne(p => p.Merchant)
            .WithMany(m => m.Payments)
            .HasForeignKey(p => p.MerchantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(p => p.Customer)
            .WithMany()
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
