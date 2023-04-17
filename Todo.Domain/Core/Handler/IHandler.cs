using Todo.Domain.Core.Command;

namespace Todo.Domain.Core.Handler;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}
