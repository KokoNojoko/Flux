// Abstraction for queries
using MediatR;

namespace Flux.Application.Abstraction
{
  public interface IQuery<out TResponse> : IRequest<TResponse>
  {

  }
}
