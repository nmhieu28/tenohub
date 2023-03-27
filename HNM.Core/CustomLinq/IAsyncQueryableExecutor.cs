using System.Linq.Expressions;

namespace HNM.Core.CustomLinq;

public interface IAsyncQueryableExecutor
{
    Task<bool> ContainsAsync<T>(IQueryable<T> queryable, T item, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync<T>(IQueryable<T> queryable,CancellationToken cancellationToken = default);
    Task<bool> AllAsync<T>(IQueryable<T> queryable,Expression<Func<T,bool>> predicate,CancellationToken cancellationToken = default);
}