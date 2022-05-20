using JWT.DataAccess.Concrete.EntityFrameworkCore.Context;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;

namespace JWT.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppRoleRepository : EfGenericRepository<AppRole>, IAppRoleDal
    {
        public EfAppRoleRepository(JwtContext context) : base(context)
        {
        }
    }
}
