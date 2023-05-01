using Todo.Domain.Features.Task.Entity;

namespace Todo.Domain.Tests.TaskTests.EntityTests;

[TestClass]
public class TaskEntityTest
{
	private readonly TaskEntity _validTask = new("Kill Joker", "Bruce Wayne", DateTime.Now);

	[TestMethod]
	public void Done_should_be_false_when_created()
		=> Assert.AreEqual(_validTask.Done, false);
}
