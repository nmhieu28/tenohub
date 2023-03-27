using System.Diagnostics.CodeAnalysis;
using HNM.Core.Domain.Entities;

namespace HNM.Core.Domain.Repositories;

public interface ICoreRepository
{
    
}
public interface IReadOnlyBaseRepository<TEntity> : ICoreRepository where TEntity : class, IEntity
{
    Task<List<TEntity>> GetAllAsync(bool includeDetails, CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetPagedListAsync(
        int skip,
        int take,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );
}

public interface IReadOnlyBaseRepository<TEntity, TKey> : IReadOnlyBaseRepository<TEntity>
    where TEntity : class, IEntity<TKey>
{
    [return: NotNull]
    Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);
    Task<TEntity> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);
}