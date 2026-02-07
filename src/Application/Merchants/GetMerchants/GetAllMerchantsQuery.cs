using Flux.Application.Abstraction.Messaging;
using Flux.Application.Merchants.GetAllmerchants;

namespace Flux.Application.Merchants.GetAllMerchants
{
  public record GetAllMerchantsQuery : IQuery<IReadOnlyCollection<GetAllMerchantsRequest>>
  {

  }  
}
