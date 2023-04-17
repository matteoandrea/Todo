using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Core.Command;

namespace Todo.Domain.Features.Task.Commands;

public class CreateTaskCommand : Notifiable<Notification>, ICommand
{
	public string Title { get; set; }
	public string User { get; set; }
	public DateTime Date { get; set; }

	public CreateTaskCommand() { }

	public CreateTaskCommand(string title, string user, DateTime date)
	{
		Title = title;
		User = user;
		Date = date;
	}

	public void Validate()
	{
		AddNotifications(
			new Contract<Notification>()
				.Requires()
				.IsGreaterOrEqualsThan(Title, 3, "Title", "Too short")
				.IsGreaterOrEqualsThan(User, 3, "User", "Too short")
			);
	}
}
