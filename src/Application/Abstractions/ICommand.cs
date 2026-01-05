// Abstraction of commands
using MediatR;

namespace Flux.Application.Abstraction
{
  public interface ICommand : IRequest
  {

  }

  public interface ICommand<out TResponse> : IRequest<TResponse>
  {

  }
}
