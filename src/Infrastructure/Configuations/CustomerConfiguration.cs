using Flux.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flux.Infrastructure.Configuations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Surname).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Email).IsRequired().HasMaxLength(255);
        builder.Property(c => c.IsActive).IsRequired().HasDefaultValue(true);

        builder.OwnsOne(
            c => c.Address,
            address =>
            {
                address.Property(a => a.Street).IsRequired().HasMaxLength(200);
                address.Property(a => a.Suburb).IsRequired().HasMaxLength(100);
                address.Property(a => a.City).IsRequired().HasMaxLength(100);
                address.Property(a => a.Province).IsRequired().HasMaxLength(100);
                address.Property(a => a.Country).IsRequired().HasMaxLength(100);
                address.Property(a => a.ZipCode).IsRequired().HasMaxLength(20);
            }
        );

        builder.HasIndex(c => c.Email).IsUnique();

        builder
            .HasOne(c => c.Merchant)
            .WithMany(m => m.Customers)
            .HasForeignKey(c => c.MerchantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
