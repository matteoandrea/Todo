using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler :
    Notifiable<Notification>,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
        => _repository = repository;


    public ICommandResult Handle(CreateTodoCommand command)
    {
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Tarefa incorreta", command.Notifications);

        var todoItem = new TodoItem(command.Title, command.User, command.Date);
        _repository.Create(todoItem);

        return new GenericCommandResult(true, "Tarefa criada", todoItem);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "falha na atualizacao", command.Notifications);


        var todoItem = _repository.GetById(command.Id, command.User);
        todoItem.UpdateTitle(command.Title);
        _repository.Update(todoItem);

        return new GenericCommandResult(true, "Tarefa Autalizada", todoItem);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Tarefa errada", command.Notifications);


        var todoItem = _repository.GetById(command.Id, command.User);
        todoItem.MarkAsDone();
        _repository.Update(todoItem);

        return new GenericCommandResult(true, "Done", todoItem);
    }

    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Tarefa errada", command.Notifications);


        var todoItem = _repository.GetById(command.Id, command.User);
        todoItem.MarkAsUndone();
        _repository.Update(todoItem);

        return new GenericCommandResult(true, "UnDone", todoItem);
    }
}
