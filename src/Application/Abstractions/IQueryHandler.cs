using MediatR;

namespace Flux.Application.Abstraction
{
  public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
  {

  }
}
