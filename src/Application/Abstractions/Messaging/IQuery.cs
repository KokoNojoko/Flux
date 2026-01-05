// Abstraction for queries
using MediatR;

namespace Flux.Application.Abstraction.Messaging
{
  public interface IQuery<out TResponse> : IRequest<TResponse>
  {

  }
}
