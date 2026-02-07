namespace Flux.Application.Merchants.GetAllmerchants
{
  public record GetAllMerchantsRequest(Guid Id, string Name, string Email, string ApiKey, string WebhookUrl, DateTime CreatedAt, bool IsActive)
  {

  }
}
