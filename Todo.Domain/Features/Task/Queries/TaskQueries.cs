using System.Linq.Expressions;
using Todo.Domain.Features.Task.Core;

namespace Todo.Domain.Features.Task.Queries;

public static class TaskQueries
{
	public static Expression<Func<TaskEntity, bool>> GetAllTasks(string user)
		=> x => x.User == user;
	public static Expression<Func<TaskEntity, bool>> GetAllDoneTasks(string user)
		=> x => x.User == user && x.Done;

	public static Expression<Func<TaskEntity, bool>> GetAllUndoneTasks(string user)
		=> x => x.User == user && x.Done == false;

	public static Expression<Func<TaskEntity, bool>> GetTaskByPeriod(string user, DateTime date, bool done)
	{
		return x =>
		x.User == user
		&& x.Date.Date == date.Date
		&& x.Done == done;
	}

}
