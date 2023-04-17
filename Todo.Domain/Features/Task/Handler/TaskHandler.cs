using Flunt.Notifications;
using Todo.Domain.Core.Command;
using Todo.Domain.Core.Handler;
using Todo.Domain.Features.Task.Commands;
using Todo.Domain.Features.Task.Entity;
using Todo.Domain.Features.Task.Repository;

namespace Todo.Domain.Features.Task.Handler;

public class TaskHandler :
	Notifiable<Notification>,
	IHandler<CreateTaskCommand>,
	IHandler<UpdateTaskCommand>,
	IHandler<MarkTaskAsDoneCommand>,
	IHandler<MarkTaskAsUndoneCommand>
{
	private readonly ITaskRepository _repository;

	public TaskHandler(ITaskRepository repository)
		=> _repository = repository;


	public ICommandResult Handle(CreateTaskCommand command)
	{
		command.Validate();
		if (!command.IsValid)
			return new GenericCommandResult(false, "Invalid Task", command.Notifications);

		TaskEntity task = new TaskEntity(command.Title, command.User, command.Date);
		_repository.Create(task);

		return new GenericCommandResult(true, "Task created ", task);
	}

	public ICommandResult Handle(UpdateTaskCommand command)
	{
		command.Validate();
		if (!command.IsValid)
			return new GenericCommandResult(false, "Ivalid update", command.Notifications);


		TaskEntity task = _repository.GetById(command.Id, command.User);

		task.UpdateTitle(command.Title);
		_repository.Update(task);

		return new GenericCommandResult(true, "Task updated", task);
	}

	public ICommandResult Handle(MarkTaskAsDoneCommand command)
	{
		command.Validate();
		if (!command.IsValid)
			return new GenericCommandResult(false, "Invalid Task", command.Notifications);


		TaskEntity task = _repository.GetById(command.Id, command.User);

		task.MarkAsDone();
		_repository.Update(task);

		return new GenericCommandResult(true, "Task marked as Done", task);
	}

	public ICommandResult Handle(MarkTaskAsUndoneCommand command)
	{
		command.Validate();
		if (!command.IsValid)
			return new GenericCommandResult(false, "Invalid Task", command.Notifications);


		TaskEntity task = _repository.GetById(command.Id, command.User);

		task.MarkAsUndone();
		_repository.Update(task);

		return new GenericCommandResult(true, "Task marked as Nndone", task);
	}
}
