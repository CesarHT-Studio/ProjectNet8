using System.Linq.Expressions;

namespace Biblioteca.Domain.Cors;

public interface ICrudRepository<TEntity, TId>
{

    Task<IReadOnlyList<TEntity>> FindAllAsync();
    
    Task<TEntity> FindByIdAsync(TId id);
    
    Task<TEntity> SaveAsync(TEntity entity);
    
    Task<IList<TEntity>> SaveAllAsync(IList<TEntity> entities);
    
    Task<TEntity> FindFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate,
        List<Expression<Func<TEntity, object>>> includes = null,
        bool disableTraking = true
        );
    
    Task<IList<TEntity>> FindAllAsync(
        Expression<Func<TEntity, bool>> predicate = null,
        List<Expression<Func<TEntity, object>>> includes = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        bool disableTraking = true
         );
    Task DeleteAsync(TEntity entity);
}