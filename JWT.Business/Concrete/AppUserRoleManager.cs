using JWT.Business.Interfaces;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;

namespace JWT.Business.Concrete
{
    public class AppUserRoleManager : GenericManager<AppUserRole>, IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal) : base(genericDal)
        {

        }
    }
}
