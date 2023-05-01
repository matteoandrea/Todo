using System.Collections.Generic;
using System.Linq.Expressions;
using Todo.Domain.Features.Task.Core;

namespace Todo.Domain.Features.Task.Repository;

public interface ITaskRepository
{
	void Create(TaskEntity task);
	void Update(TaskEntity task);
	TaskEntity GetById(Guid id, string user);
	IEnumerable<TaskEntity> GetAll(string user);
	IEnumerable<TaskEntity> GetAllDone(string user);
	IEnumerable<TaskEntity> GetAllUndone(string user);
	IEnumerable<TaskEntity> GetByPeriod(string user, DateTime date, bool done);
}
