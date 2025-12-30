namespace Flux.Domain.Merchants
{
  public class Merchant : BaseEntity, IAggregateRoot
  {
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string ApiKey { get; private set; } = null!;
    public string WebhookUrl { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
  }
}
