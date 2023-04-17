namespace Todo.Domain.Core.Entities;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; private set; }

    protected Entity()
        => Id = Guid.NewGuid();


    public bool Equals(Entity? other)
            => Id == other?.Id;
}
