using JWT.Business.Interfaces;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;

namespace JWT.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {

        }
    }
}
