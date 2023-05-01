using Todo.Domain.Features.Task.Core;
using Todo.Domain.Features.Task.Queries;

namespace Todo.Domain.Tests.TaskTests.QueriesTest;

[TestClass]
internal class TaskQueriesTest
{
	private readonly List<TaskEntity> _tasks;

	public TaskQueriesTest()
	{
		_tasks = new()
		{
			new TaskEntity("Tarefa 1", "UserA", DateTime.Now),
			new TaskEntity("Tarefa 2", "UserA", DateTime.Now),
			new TaskEntity("Tarefa 3", "UserB", DateTime.Now),
			new TaskEntity("Tarefa 4", "UserA", DateTime.Now),
			new TaskEntity("Tarefa 5", "UserB", DateTime.Now)
		};
	}

	[TestMethod]
	public void Valid_All_User_Tasks()
	{
		IQueryable<TaskEntity> result = _tasks.AsQueryable().Where(TaskQueries.GetAll("UserB"));
		Assert.AreEqual(2, result.Count());
	}
}
