using Flux.Application.Abstraction.Messaging;
using Flux.Application.Merchants.GetAllmerchants;
using SharedKernal;

namespace Flux.Application.Merchants.GetAllMerchants
{
    internal sealed class GetAllMerchantsQueryHandler : IQueryHandler<GetAllMerchantsQuery, IReadOnlyCollection<GetAllMerchantsRequest>>
    {
        public GetAllMerchantsQueryHandler()
        {
        }

        public async Task<Result<IReadOnlyCollection<GetAllMerchantsRequest>>> Handle(GetAllMerchantsQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
