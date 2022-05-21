using JWT.Entities.Concrete;
using JWT.Entities.Dtos.AppUserDtos;

namespace JWT.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserName(string userName);
        Task<bool> CheckPassword(AppUserLoginDto model);
        Task<List<AppRole>> GetRolesByUserName(string userName);

    }
}
