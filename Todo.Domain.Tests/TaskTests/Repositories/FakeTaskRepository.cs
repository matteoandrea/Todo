using Todo.Domain.Features.Task.Entity;
using Todo.Domain.Features.Task.Repository;

namespace Todo.Domain.Tests.TaskTests.Repositories;

public class FakeTaskRepository : ITaskRepository
{
	public void Create(TaskEntity todoItem) { }

	public TaskEntity GetById(Guid id, string user)
	{
		return new TaskEntity("", "", DateTime.Now);
	}

	public void Update(TaskEntity todoItem)
	{

	}
}
