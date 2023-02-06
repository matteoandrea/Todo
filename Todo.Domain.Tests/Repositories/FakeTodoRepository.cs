﻿using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todoItem)
    {

    }

    public TodoItem GetById(Guid id, string user)
    {
        return new TodoItem("", "", DateTime.Now);
    }

    public void Update(TodoItem todoItem)
    {

    }
}
