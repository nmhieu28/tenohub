using System.Collections.ObjectModel;
using HNM.Core.UnitOfWork;

namespace HNM.Core.Domain.Entities;

public abstract class BaseAggregateRoot : Entity, IAggregateRoot, IGeneratesDomainEvent
{
    private readonly ICollection<DomainEventRecord> _localEvents = new Collection<DomainEventRecord>();
    private readonly ICollection<DomainEventRecord> _distributedEvents = new Collection<DomainEventRecord>();
    
    public IEnumerable<DomainEventRecord> GetLocalEvents()
    {
        return _localEvents;
    }

    public IEnumerable<DomainEventRecord> GetDistributedEvents()
    {
        return _distributedEvents;
    }

    public void ClearLocalEvents()
    {
        _localEvents.Clear();
    }

    public void ClearDistributedEvents()
    {
        _distributedEvents.Clear();
    }

    protected virtual void AddLocalEvent(object eventData)
    {
        _localEvents.Add(new DomainEventRecord(eventData,EventOrderGenerator.GetNext()));
    }

    protected virtual void AddDistributedEvent(object eventData)
    {
        _distributedEvents.Add(new DomainEventRecord(eventData,EventOrderGenerator.GetNext()));
    }
}

public abstract class BaseAggregateRoot<TKey>: Entity<TKey>, IAggregateRoot<TKey>, IGeneratesDomainEvent
{
    private readonly ICollection<DomainEventRecord> _localEvents = new Collection<DomainEventRecord>();
    private readonly ICollection<DomainEventRecord> _distributedEvents = new Collection<DomainEventRecord>();

    protected BaseAggregateRoot()
    {
        
    }
    protected BaseAggregateRoot(TKey id) : base(id)
    {
        
    }
    public IEnumerable<DomainEventRecord> GetLocalEvents()
    {
        return _localEvents;
    }

    public IEnumerable<DomainEventRecord> GetDistributedEvents()
    {
        return _distributedEvents;
    }

    public void ClearLocalEvents()
    {
        _localEvents.Clear();
    }

    public void ClearDistributedEvents()
    {
        _distributedEvents.Clear();
    }

    protected virtual void AddLocalEvent(object eventData)
    {
        _localEvents.Add(new DomainEventRecord(eventData,EventOrderGenerator.GetNext()));
    }

    protected virtual void AddDistributedEvent(object eventData)
    {
        _distributedEvents.Add(new DomainEventRecord(eventData,EventOrderGenerator.GetNext()));
    }
}