using Todo.Domain.Core;
using Todo.Domain.Core.Entities;

namespace Todo.Domain.Features.Task.Core;

public class TaskEntity : Entity
{
    public TaskEntity(string title, string user, DateTime date)
    {
        Title = title;
        Done = false;
        Date = date;
        User = user;
    }

    public string Title { get; private set; }
    public bool Done { get; private set; }
    public DateTime Date { get; private set; }
    public string User { get; private set; }

    public void MarkAsDone()
        => Done = true;

    public void MarkAsUndone()
        => Done = false;

    public void UpdateTitle(string title)
        => Title = title;
}
