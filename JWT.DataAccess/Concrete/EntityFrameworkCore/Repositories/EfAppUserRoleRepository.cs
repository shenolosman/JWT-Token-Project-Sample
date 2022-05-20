using JWT.DataAccess.Concrete.EntityFrameworkCore.Context;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;

namespace JWT.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRoleRepository : EfGenericRepository<AppUserRole>, IAppUserRoleDal
    {
        public EfAppUserRoleRepository(JwtContext context) : base(context)
        {
        }
    }
}
