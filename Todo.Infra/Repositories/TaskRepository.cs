using Microsoft.EntityFrameworkCore;
using Todo.Domain.Features.Task.Core;
using Todo.Domain.Features.Task.Queries;
using Todo.Domain.Features.Task.Repository;
using Todo.Infra.Data.Context;

namespace Todo.Infra.Repositories;

public class TaskRepository : ITaskRepository
{
	private readonly DataContext _context;

	public TaskRepository(DataContext context)
	{
		_context = context;
	}

	public void Create(TaskEntity task)
	{
		_context.Tasks.Add(task);
		_context.SaveChanges();
	} 

	public IEnumerable<TaskEntity> GetAllDone(string user)
	{
		return _context.Tasks
			.AsNoTracking()
			.Where(TaskQueries.GetAllDone(user))
			.OrderBy(x => x.Date);
	}

	public IEnumerable<TaskEntity> GetAll(string user)
	{
		return _context.Tasks
			.AsNoTracking()
			.Where(TaskQueries.GetAll(user))
			.OrderBy(x => x.Date);
	}

	public IEnumerable<TaskEntity> GetAllUndone(string user)
	{
		return _context.Tasks
			.AsNoTracking()
			.Where(TaskQueries.GetAllUndone(user))
			.OrderBy(x => x.Date);
	}

	public TaskEntity GetById(Guid id, string user)
	{
		return _context.Tasks
			.FirstOrDefault(TaskQueries.GetById(id, user));
	}

	public IEnumerable<TaskEntity> GetByPeriod(string user, DateTime date, bool done)
	{
		return _context.Tasks
			.AsNoTracking()
			.Where(TaskQueries.GetByPeriod(user, date, done))
			.OrderBy(x => x.Date);
	}

	public void Update(TaskEntity task)
	{
		_context.Entry(task).State = EntityState.Modified;
		_context.SaveChanges();
	}
}
