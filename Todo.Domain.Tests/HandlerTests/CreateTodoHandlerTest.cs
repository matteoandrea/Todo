using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTest
{
    private readonly CreateTodoCommand _invalidCreatecommand = new("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCreatecommand = new("Kill Joker", "Bruce", DateTime.Now);
    private readonly TodoHandler _handler = new(new FakeTodoRepository());
    private GenericCommandResult _result = new();

    [TestMethod]
    public void Invalid_command_should_stop_exec()
    {
        _result = (GenericCommandResult)_handler.Handle(_invalidCreatecommand);
        Assert.AreEqual(_result.Success, false);
    }

    [TestMethod]
    public void Valid_command_should_create_todo_item()
    {
        _result = (GenericCommandResult)_handler.Handle(_validCreatecommand);
        Assert.AreEqual(_result.Success, true);
    }
}
