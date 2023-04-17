using Todo.Domain.Features.Task.Entity;

namespace Todo.Domain.Features.Task.Repository
{
	internal class TaskRepository : ITaskRepository
	{

		public void Create(TaskEntity todoItem)
		{
			throw new NotImplementedException();
		}

		public TaskEntity GetById(Guid id, string user)
		{
			throw new NotImplementedException();
		}

		public void Update(TaskEntity todoItem)
		{
			throw new NotImplementedException();
		}
	}
}
