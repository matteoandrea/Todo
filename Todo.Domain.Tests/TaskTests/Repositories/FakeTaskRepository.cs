using Todo.Domain.Features.Task.Core;
using Todo.Domain.Features.Task.Repository;

namespace Todo.Domain.Tests.TaskTests.Repositories;

public class FakeTaskRepository : ITaskRepository
{

	public void Create(TaskEntity task)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<TaskEntity> GetAll(string user)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<TaskEntity> GetAllDone(string user)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<TaskEntity> GetAllUndone(string user)
	{
		throw new NotImplementedException();
	}

	public TaskEntity GetById(Guid id, string user)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<TaskEntity> GetByPeriod(string user, DateTime date, bool done)
	{
		throw new NotImplementedException();
	}

	public void Update(TaskEntity task)
	{
		throw new NotImplementedException();
	}

	TaskEntity ITaskRepository.GetById(Guid id, string user)
	{
		throw new NotImplementedException();
	}
}
