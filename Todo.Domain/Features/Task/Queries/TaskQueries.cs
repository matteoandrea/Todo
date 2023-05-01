using System.Linq.Expressions;
using Todo.Domain.Features.Task.Core;

namespace Todo.Domain.Features.Task.Queries;

public static class TaskQueries
{
	public static Expression<Func<TaskEntity, bool>> GetAll(string user)
		=> x => x.User == user;
	public static Expression<Func<TaskEntity, bool>> GetAllDone(string user)
		=> x => x.User == user && x.Done;

	public static Expression<Func<TaskEntity, bool>> GetAllUndone(string user)
		=> x => x.User == user && x.Done == false;

	public static Expression<Func<TaskEntity, bool>> GetByPeriod(string user, DateTime date, bool done)
	{
		return x =>
		x.User == user
		&& x.Date.Date == date.Date
		&& x.Done == done;
	}

	public static Expression<Func<TaskEntity, bool>> GetById(Guid id, string user)
	{
		return x =>
		x.Id == id
		&& x.User == user;
	}

}
