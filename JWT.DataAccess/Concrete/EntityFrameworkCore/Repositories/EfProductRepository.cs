using JWT.DataAccess.Concrete.EntityFrameworkCore.Context;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;

namespace JWT.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductDal
    {
        public EfProductRepository(JwtContext context) : base(context)
        {
        }
    }
}
