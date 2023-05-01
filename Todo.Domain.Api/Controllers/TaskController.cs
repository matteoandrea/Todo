using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Core.Command;
using Todo.Domain.Features.Task.Commands;
using Todo.Domain.Features.Task.Core;
using Todo.Domain.Features.Task.Handler;
using Todo.Domain.Features.Task.Repository;

namespace Todo.Api.Controllers;

[ApiController]
[Route("v1/tasks")]
public class TaskController : ControllerBase
{
	[HttpPost]
	public GenericCommandResult Create(
		[FromBody] CreateTaskCommand command,
		[FromServices] TaskHandler handler)
	{
		command.User = "brucewayne";
		return (GenericCommandResult)handler.Handle(command);
	}

	[HttpGet]
	public IEnumerable<TaskEntity> GetAll(
		[FromServices] ITaskRepository repository)
	{
		return repository.GetAll("brucewayne");
	}

	[HttpGet("done")]
	public IEnumerable<TaskEntity> GetAllDone(
		[FromServices] ITaskRepository repository)
	{
		return repository.GetAllDone("brucewayne");
	}

	[HttpGet("done/today")]
	public IEnumerable<TaskEntity> GetAllDoneForToday(
		[FromServices] ITaskRepository repository)
	{
		return repository.GetByPeriod(
			"brucewayner",
			DateTime.Now.Date,
			true);
	}

	[HttpGet("done/tomorrow")]
	public IEnumerable<TaskEntity> GetAllDoneForTomorrow(
		[FromServices] ITaskRepository repository)
	{
		return repository.GetByPeriod(
			"brucewayner",
			DateTime.Now.Date.AddDays(1),
			true);
	}

	[HttpGet("undone")]
	public IEnumerable<TaskEntity> GetAllUndone(
	[FromServices] ITaskRepository repository)
	{
		return repository.GetAllUndone("brucewayne");
	}

	[HttpGet("undone/today")]
	public IEnumerable<TaskEntity> GetAllUndoneForToday(
		[FromServices] ITaskRepository repository)
	{
		return repository.GetByPeriod(
			"brucewayne",
			DateTime.Now.Date,
			false);
	}

	[HttpGet("undone/tomorrow")]
	public IEnumerable<TaskEntity> GetAllUndoneForTomorrow(
		[FromServices] ITaskRepository repository)
	{
		return repository.GetByPeriod(
			"brucewayne",
			DateTime.Now.Date.AddDays(1),
			false);
	}

	[HttpPut]
	public GenericCommandResult Update(
		[FromBody] UpdateTaskCommand command,
		[FromServices] TaskHandler handler)
	{
		command.User = "brucewayne";
		return (GenericCommandResult)handler.Handle(command);
	}

	[HttpPut("mark-as-done")]
	public GenericCommandResult MarkAsDone(
		[FromBody] MarkTaskAsDoneCommand command,
		[FromServices] TaskHandler handler)
	{
		command.User = "brucewayne";
		return (GenericCommandResult)handler.Handle(command);
	}
}
