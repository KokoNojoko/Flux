using Flux.Application.Abstraction.Messaging;
using Flux.Application.Merchants.GetAllmerchants;

namespace Flux.Application.Merchants.GetAllMerchants
{
    internal class GetAllMerchantsQueryHandler : IQueryHandler<GetAllMerchantsQuery, IReadOnlyCollection<GetAllMerchantsDTO>>
    {
        private readonly IFluxDbContext _context;

        public GetAllMerchantsQueryHandler(IFluxDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<GetAllMerchantsDTO>> Handle(GetAllMerchantsQuery request, CancellationToken cancellationToken)
        {
          
        }
    }
}
