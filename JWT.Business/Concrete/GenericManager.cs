using JWT.Business.Interfaces;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Interfaces;

namespace JWT.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericDal<TEntity> _genericDal;

        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            this._genericDal = genericDal;
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await _genericDal.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _genericDal.GetById(id);
        }

        public async Task Delete(TEntity entity)
        {
            await _genericDal.Delete(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _genericDal.Update(entity);
        }

        public async Task Add(TEntity entity)
        {
            await _genericDal.Add(entity);
        }
    }
}
