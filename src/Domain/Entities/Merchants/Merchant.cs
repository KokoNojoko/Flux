using Flux.Domain.Entities.Customers;
using Flux.Domain.Entities.Payments;

namespace Flux.Domain.Entities.Merchants
{
  public sealed class Merchant : BaseEntity, IAggregateRoot
  {
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string ApiKey { get; private set; }
    public string WebhookUrl { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyCollection<Customer> Customers = new List<Customer>();
    public IReadOnlyCollection<Payment> Payments = new List<Payment>();
    
    private Merchant()
    {
        
    }


    private Merchant(string name, string email, string apiKey, string webhookUrl, DateTime createdAt)
    {
        Name = name;
        Email = email;
        ApiKey = apiKey;
        WebhookUrl = webhookUrl;
        CreatedAt = createdAt;
    }

    public static Merchant Create(string name, string email, string apiKey, string webhookUrl, DateTime createdAt)
    {
      return new Merchant(name, email, apiKey, webhookUrl, createdAt);
    }
  }
}
