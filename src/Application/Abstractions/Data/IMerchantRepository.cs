using Flux.Domain.Entities.Merchants;

namespace Flux.Application.Abstractions.Data
{
  public interface IMerchantRepository
  {
    Task AddAsync(Merchant merchant, CancellationToken cancellationToken);
  }
}
