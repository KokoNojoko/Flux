using SharedKernal;

namespace Flux.Application.Abstraction.Messaging
{
  public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
  {
    // Unfirom return type - 'Result'
    Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
  }

  public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
  {
    // Uniform return type - 'Result<TResponse>'
    Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
  }
}
