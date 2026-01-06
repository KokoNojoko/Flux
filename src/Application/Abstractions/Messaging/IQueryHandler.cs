using SharedKernal;
namespace Flux.Application.Abstraction.Messaging
{
  public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
  {
    // Uniform return type - 'Result<TResponse>'
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
  }
}
