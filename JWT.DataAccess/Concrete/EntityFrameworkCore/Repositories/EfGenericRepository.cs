using JWT.DataAccess.Concrete.EntityFrameworkCore.Context;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JWT.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        //private readonly JwtContext _context;

        //public EfGenericRepository(JwtContext context)
        //{
        //    _context = context;
        //}
        public async Task<List<TEntity>> GetAll()
        {
            await using var _context = new JwtContext();
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            await using var _context = new JwtContext();
            return await _context.Set<TEntity>().Where(filter).ToListAsync();
        }
        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            await using var _context = new JwtContext();
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }
        public async Task<TEntity> GetById(int id)
        {
            await using var _context = new JwtContext();
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async Task Add(TEntity entity)
        {
            await using var _context = new JwtContext();
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(TEntity entity)
        {
            await using var _context = new JwtContext();
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(TEntity entity)
        {
            await using var _context = new JwtContext();
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
