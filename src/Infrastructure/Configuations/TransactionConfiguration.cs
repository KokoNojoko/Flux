using Flux.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flux.Infrastructure.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Amount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(t => t.Currency).IsRequired().HasConversion<string>().HasMaxLength(3);
        builder.Property(t => t.Type).IsRequired().HasConversion<string>().HasMaxLength(20);
        builder.Property(t => t.Status).IsRequired().HasConversion<string>().HasMaxLength(20);
        builder.Property(t => t.ProviderTransactionId).HasMaxLength(100);

        builder
            .HasOne(t => t.Payment)
            .WithOne(p => p.Transaction)
            .HasForeignKey<Transaction>(t => t.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
