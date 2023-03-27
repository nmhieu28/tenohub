using System.Linq.Expressions;
using HNM.Core.CustomLinq;
using HNM.Core.Domain.Entities;

namespace HNM.Core.Domain.Repositories;

public interface IReadOnlyRepository<TEntity> : IReadOnlyBaseRepository<TEntity> where TEntity : class, IEntity
{
   IAsyncQueryableExecutor AsyncExecutor { get; }
   Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = false, CancellationToken cancellationToken = default);
}

public interface IReadOnlyRepository<TEntity,TKey> : IReadOnlyBaseRepository<TEntity,TKey> where TEntity : class, IEntity<TKey>
{
}