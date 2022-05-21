using JWT.Business.Interfaces;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;
using JWT.Entities.Dtos.AppUserDtos;

namespace JWT.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) : base(genericDal)
        {
            _appUserDal = appUserDal;
        }

        public async Task<AppUser> FindByUserName(string userName)
        {
            return await _appUserDal.GetByFilter(x => x.UserName == userName);
        }

        public async Task<bool> CheckPassword(AppUserLoginDto model)
        {
            var appUser = await _appUserDal.GetByFilter(x => x.UserName == model.UserName);
            return appUser.Password == model.Password ? true : false;
        }
    }
}
