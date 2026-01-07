using Flux.Application.Abstraction.Messaging;
using SharedKernal;

namespace Flux.Application.Merchants.Create
{
    internal sealed class CreateMerchantCommandHandler : ICommandHandler<CreateMerchantCommand>
    {
        public Task<Result> Handle(CreateMerchantCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
