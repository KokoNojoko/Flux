using Flux.Domain.Entities.Merchants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flux.Infrastructure.Configurations;

public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
{
    public void Configure(EntityTypeBuilder<Merchant> builder)
    {
        builder.ToTable("merchants");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Email).IsRequired().HasMaxLength(255);
        builder.Property(m => m.ApiKey).IsRequired().HasMaxLength(64);
        builder.Property(m => m.WebhookUrl).IsRequired().HasMaxLength(512);
        builder.Property(m => m.IsActive).IsRequired().HasDefaultValue(true);

        builder.HasIndex(m => m.Email).IsUnique();
        builder.HasIndex(m => m.ApiKey).IsUnique();
    }
}
