// Some fields should be enums
using Flux.Domain.Entities.Payments;
using Flux.Domain.Enums;
using SharedKernal;

namespace Flux.Domain.Entities.Transactions
{
  public sealed class Transaction : BaseEntity, IAggregateRoot
  {
    public Guid PaymentId { get; private set; }
    public TransactionType Type { get; private set; }
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }
    public TransactionStatus Status { get; private set; }
    public string? ProviderTransactionId { get; private set; }
    public Payment Payment { get; private set; }

    private Transaction()
    {
        
    }

    
    private Transaction(Guid paymentId, TransactionType type, decimal amount, Currency currency, TransactionStatus status, string? providerTransactionId)
    {
        PaymentId = paymentId;
        Type = type;
        Amount = amount;
        Currency = currency;
        Status = status;
        ProviderTransactionId = providerTransactionId;
    }

    public static Transaction Create(Guid paymentId, TransactionType type, decimal amount, Currency currency, TransactionStatus status, string? providerTransactionId)
    {
      return new Transaction(paymentId, type, amount, currency, status, providerTransactionId);
    }
  }
}
