using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Core.Command;

namespace Todo.Domain.Features.Task.Commands;

public class UpdateTaskCommand : Notifiable<Notification>, ICommand
{
    public UpdateTaskCommand() { }

    public UpdateTaskCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(Title, 3, "Title", "Invalid Title")
                .IsGreaterOrEqualsThan(User, 6, "User", "Invalid User")
        );
    }
}
