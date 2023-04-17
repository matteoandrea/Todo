using Todo.Domain.Features.Task.Commands;

namespace Todo.Domain.Tests.TaskTests.CommandTests;

[TestClass]
public class CreateTaskCommandTests
{
    private readonly CreateTaskCommand _invalidCreatecommand = new CreateTaskCommand("", "", DateTime.Now);
    private readonly CreateTaskCommand _validCreatecommand = new CreateTaskCommand("Kill Joker", "Bruce", DateTime.Now);

    public CreateTaskCommandTests()
    {
        _invalidCreatecommand.Validate();
        _validCreatecommand.Validate();
    }

    [TestMethod]
    public void Invalid_command()
        => Assert.AreEqual(_invalidCreatecommand.IsValid, false);

    [TestMethod]
    public void Valid_command()
        => Assert.AreEqual(_validCreatecommand.IsValid, true);
}