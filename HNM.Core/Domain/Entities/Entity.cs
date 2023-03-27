namespace HNM.Core.Domain.Entities;

public abstract class Entity : IEntity
{
    protected Entity()
    {
    }

    public abstract object[] GetKeys();
}

public abstract class Entity<TKey> : Entity, IEntity<TKey>
{
    public virtual TKey Id { get; protected set; }
    protected Entity()
    {
        
    }
    protected Entity(TKey id)
    {
        Id = id;
    }

    public override object[] GetKeys()
    {
        return new object[] { Id };
    }

    public override string ToString()
    {
        return $"[Entity: {GetType().Name}] Id = {Id}";
    }
}