using JWT.Business.Interfaces;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;

namespace JWT.Business.Concrete
{
    public class AppRoleManager : GenericManager<AppRole>, IAppRoleService
    {
        private readonly IGenericDal<AppRole> _genericDal;

        public AppRoleManager(IGenericDal<AppRole> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<AppRole> FindByName(string roleName)
        {
            return await _genericDal.GetByFilter(x => x.Name == roleName);
        }
    }
}
