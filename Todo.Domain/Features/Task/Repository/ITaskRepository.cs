using Todo.Domain.Features.Task.Entity;

namespace Todo.Domain.Features.Task.Repository;

public interface ITaskRepository
{
    void Create(TaskEntity todoItem);
    void Update(TaskEntity todoItem);
    TaskEntity GetById(Guid id, string user);
}
