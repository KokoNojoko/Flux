namespace Flux.Application.Merchants.GetAllmerchants
{
  public record GetAllMerchantsDTO(Guid Id, string Name, string Email, string ApiKey, string WebhookUrl, DateTime CreatedAt, bool IsActive)
  {

  }
}
