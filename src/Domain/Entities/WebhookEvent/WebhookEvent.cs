using Flux.Domain.Enums;
using SharedKernal;

namespace Flux.Domain.Entities.WebhookEvent
{
    public sealed class WebhookEvent : BaseEntity
    {
      public Guid MerchantId { get; private set; }
      public Guid PaymentId { get; private set; }
      public Guid CustomerId { get; private set; }
      public string Trigger { get; private set; }
      public string Payload { get; private set; }
      public string WebhookUrl { get; private set; }
      public WebhookEventType EventType { get; private set; }
      public WebhookStatus Status { get; private set; }
      public int AttemptCount { get; private set; }
      public DateTime? NextRetryAt { get; private set; }
      public DateTime? DeliveredAt { get; private set; }
      public string? FailureReason { get; private set; }
      public DateTime CreatedAt { get; private set; }
      public DateTime? UpdatedAt { get; private set; }

      private WebhookEvent()
      {
          
      }

      private WebhookEvent(Guid merchantId, Guid paymentId, Guid customerId, string trigger, string payload, string webhookUrl, WebhookEventType eventType)
      {
        MerchantId = merchantId;
        PaymentId = paymentId;
        CustomerId = customerId;
        Trigger = trigger;
        Payload = payload;
        WebhookUrl = webhookUrl;
        EventType = eventType;
        Status = WebhookStatus.pending;
        CreatedAt = DateTime.UtcNow;
      }

      public static WebhookEvent Create(Guid merchantId, Guid paymentId, Guid customerId, string trigger, string payload, string webhookUrl, WebhookEventType eventType)
      {
        return new WebhookEvent(merchantId, paymentId, customerId, trigger, payload, webhookUrl, eventType);
      }

      public void MarkAsDelivered()
      {
        Status = WebhookStatus.Delivered;
        DeliveredAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
      }

      public void MarkAsFailed(string failureReason, DateTime? nextRetryAt = null)
      {
        AttemptCount++;
        Status = WebhookStatus.Failed;
        FailureReason = failureReason;

        // Exponential backoff: 1min, 2min, 15min, 1hr, etc.
        var delayMinutes = AttemptCount switch
        {
          1 => 1,
          2 => 2,
          3 => 15,
          4 => 60,
          _ => 360
        };

        if (AttemptCount < 5)
        {
          NextRetryAt = DateTime.UtcNow.AddMinutes(delayMinutes);
          Status = WebhookStatus.Retrying;
        }
        else
        {
          NextRetryAt = null; // No more retries
        }
        UpdatedAt = DateTime.UtcNow;
      }
    }
}
