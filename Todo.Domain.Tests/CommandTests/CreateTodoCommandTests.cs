using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCreatecommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCreatecommand = new CreateTodoCommand("Kill Joker", "Bruce", DateTime.Now);

    public CreateTodoCommandTests()
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