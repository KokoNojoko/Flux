// Don't forget to that some of these variables should have enums
using Flux.Domain.Entities.Customers;
using Flux.Domain.Entities.Merchants;
using Flux.Domain.Entities.Transactions;
using Flux.Domain.Enums;
using SharedKernal;


namespace Flux.Domain.Entities.Payments
{
  public sealed class Payment : BaseEntity, IAggregateRoot
  {
    public Guid MerchantId { get; private set; }
    public Guid? CustomerId { get; private set; }
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }
    public PaymentStatus Status { get; private set; }
    public string IdempotencyKey { get; private set; }
    public string Description { get; private set; }
    public object? Metadata { get; private set; }
    public DateTime UpdatedAt{ get; private set; }
    public Merchant Merchant { get; private set; }
    public Customer Customer { get; private set; }
    public Transaction Transaction { get; private set; }

    private Payment()
    {
        
    }

    
    private Payment(Guid merchantId, Guid? customerId, decimal amount, string idempotencykey, string description, object? metadata, DateTime updatedAt)
    {
       MerchantId = merchantId;
       CustomerId = customerId;
       Amount = amount;
       IdempotencyKey = idempotencykey;
       Description = description;
       Metadata = metadata;
       UpdatedAt = updatedAt;
    }
  }
}
