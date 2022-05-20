using JWT.DataAccess.Concrete.EntityFrameworkCore.Context;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;

namespace JWT.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserRepository(JwtContext context) : base(context)
        {
        }
    }
}
