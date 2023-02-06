using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoItemTest
{
    private readonly TodoItem _todoItem = new("Kill Joker", "Bruce Wayne", DateTime.Now);

    [TestMethod]
    public void Done_should_be_false_when_created()
        => Assert.AreEqual(_todoItem.Done, false);
}
