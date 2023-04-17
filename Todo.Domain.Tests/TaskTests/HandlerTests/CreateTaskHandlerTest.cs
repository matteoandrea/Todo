using Todo.Domain.Core.Command;
using Todo.Domain.Features.Task.Commands;
using Todo.Domain.Features.Task.Handler;
using Todo.Domain.Tests.TaskTests.Repositories;

namespace Todo.Domain.Tests.TaskTests.HandlerTests;

[TestClass]
public class CreateTaskHandlerTest
{
    private readonly CreateTaskCommand _invalidCreatecommand = new("", "", DateTime.Now);
    private readonly CreateTaskCommand _validCreatecommand = new("Kill Joker", "Bruce", DateTime.Now);
    private readonly TaskHandler _handler = new(new FakeTaskRepository());
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
