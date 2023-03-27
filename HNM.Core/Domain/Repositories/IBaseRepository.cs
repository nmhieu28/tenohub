using HNM.Core.Domain.Entities;

namespace HNM.Core.Domain.Repositories;

public interface IBaseRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
{
    
}
public interface IBaseRepository<TEntity,TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
{
    
}