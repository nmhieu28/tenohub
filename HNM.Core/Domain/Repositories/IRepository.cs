using HNM.Core.Domain.Entities;

namespace HNM.Core.Domain.Repositories;

public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>, IBaseRepository<TEntity>
    where TEntity : class, IEntity
{
    
}
public interface IRepository<TEntity,TKey> : IRepository<TEntity>, IReadOnlyRepository<TEntity,TKey>, IBaseRepository<TEntity,TKey>
    where TEntity : class, IEntity<TKey>
{
    
}
