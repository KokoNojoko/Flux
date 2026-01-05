using MediatR;

namespace Flux.Application.Abstraction.Messaging
{
  public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
  {

  }
}
