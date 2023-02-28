using System.Linq.Expressions;

namespace BulungurAcademy.Infrastructure.Repositories;

public interface IRepository<TEntity>
{
    ValueTask<TEntity> InsertAsync(TEntity entity);
    IQueryable<TEntity> SelectAll();
    ValueTask<TEntity> SelectByIdAsync<TKey>(TKey id);

    ValueTask<TEntity> SelectByIdWithDetailsAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes);
    IQueryable<TEntity> SelectAllWithDetailsAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes);

    ValueTask<TEntity> UpdateAsync(TEntity entity);
    ValueTask<TEntity> DeleteAsync(TEntity entity);
}
