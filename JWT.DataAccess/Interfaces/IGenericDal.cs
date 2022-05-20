using JWT.Entities.Interfaces;
using System.Linq.Expressions;

namespace JWT.DataAccess.Interfaces
{
    public interface IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetById(int id);
        Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task Add(TEntity entity);
    }
}
