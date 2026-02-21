using Flux.Domain.Entities.WebhookEvent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flux.Infrastructure.Configurations;

public class WebhookEventConfiguration : IEntityTypeConfiguration<WebhookEvent>
{
    public void Configure(EntityTypeBuilder<WebhookEvent> builder)
    {
        builder.ToTable("webhook_events");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Trigger).IsRequired().HasMaxLength(200);
        builder.Property(w => w.Payload).IsRequired();
        builder.Property(w => w.WebhookUrl).IsRequired().HasMaxLength(512);
        builder.Property(w => w.EventType).IsRequired().HasConversion<string>().HasMaxLength(50);
        builder.Property(w => w.Status).IsRequired().HasConversion<string>().HasMaxLength(20);
        builder.Property(w => w.AttemptCount).IsRequired().HasDefaultValue(0);
        builder.Property(w => w.NextRetryAt);
        builder.Property(w => w.DeliveredAt);
        builder.Property(w => w.FailureReason).HasMaxLength(500);
        builder.Property(w => w.UpdatedAt);

        builder.HasIndex(w => w.MerchantId);
        builder.HasIndex(w => w.PaymentId);
        builder.HasIndex(w => new { w.Status, w.NextRetryAt });
    }
}
