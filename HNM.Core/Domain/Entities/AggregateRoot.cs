namespace HNM.Core.Domain.Entities;

public abstract class AggregateRoot : BaseAggregateRoot, IHasConcurrencyStamp
{
    public virtual string ConcurrencyStamp { set; get; }

    protected AggregateRoot()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
    }
}

public abstract class AggregateRoot<TKey> : BaseAggregateRoot<TKey>, IHasConcurrencyStamp
{
    public virtual string ConcurrencyStamp { set; get; }
    protected AggregateRoot()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
    }
    protected AggregateRoot(TKey id) : base(id)
    {
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
    }
}