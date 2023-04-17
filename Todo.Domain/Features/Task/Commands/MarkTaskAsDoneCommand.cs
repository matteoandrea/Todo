using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Core.Command;

namespace Todo.Domain.Features.Task.Commands;

public class MarkTaskAsDoneCommand : Notifiable<Notification>, ICommand
{
    public MarkTaskAsDoneCommand() { }

    public MarkTaskAsDoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(User, 6, "User", "Invalid User")
        );
    }
}
