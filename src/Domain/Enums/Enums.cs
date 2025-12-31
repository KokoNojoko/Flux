namespace Flux.Domain.Enums
{
  public enum Currency
  {
    ZAR,
    GBP,
    USD,
    EUR,
    JPY,
    AUD,
    CAD,
    CHF,
    CNY
  }

  public enum PaymentStatus
  {
    Pending,      // Just created, not yet authorised
    Authorised,   // Funds reserved, not captured 
    Captured,     // Money taken, payment complete
    Failed,       // Authorisation / capture failed 
    Refunded,     // Money returned to user 
    Voided        // Cancelled before capture
  }

  public enum TransactionType
  {
    Authorise,
    Capture,
    Refund,
    Void
  }

  public enum TransactionStatus
  {
    Pending,
    Success,
    Failed
  }

  public enum WebhookEventType
  {
    PaymentAuthorised,
    PaymentCaptured,
    PaymentFailed,
    PaymentRefunded,
    PaymentVoided
  }

  public enum WebhookStatus
  {
    pending,
    Delivered,
    Failed,
    Retrying
  }

  public enum RefundReason
  {
    RequestedByCustomer,
    Fruad,
    Duplicate,
    ProductNotRecived,
    ProductDefective,
    Other
  }

  public enum PaymentAuthorised
  {
    CreditCard,
    DebitCard,
    Banktransfer,
    EFT,
    Wallet // Digital Wallets
  }
}
