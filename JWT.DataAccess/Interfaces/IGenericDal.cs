using JWT.Entities.Interfaces;
using System.Linq.Expressions;

namespace JWT.DataAccess.Interfaces
{
    public interface IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsyncByFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetAsyncByFilter(Expression<Func<TEntity, bool>> filter);
        Task DeleteAync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task AddAsync(TEntity entity);
    }
}
