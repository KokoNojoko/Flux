using Flux.Application.Abstraction.Messaging;

namespace Flux.Application.Merchants.Create
{
  public sealed record CreateMerchantCommand(Guid Id, string Name, string Email, string ApiKey, string WebhookUrl, DateTime CreatedAt, bool IsActive) : ICommand;
}
