using Flux.Application.Abstraction.Messaging;

namespace Flux.Application.Merchants.GetAllMerchants
{
    internal class GetAllMerchantsQueryHandler : IQueryHandler<GetAllMerchantsQuery, IReadOnlyCollection<GetAllMerchantsRequest>>
    {
        public GetAllMerchantsQueryHandler()
        {
        }
        public async Task<IReadOnlyCollection<GetAllMerchantsRequest>> Handle(GetAllMerchantsQuery request, CancellationToken cancellationToken)
        {
          
        }
    }
}
