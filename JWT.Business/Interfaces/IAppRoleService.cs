using JWT.Entities.Concrete;

namespace JWT.Business.Interfaces
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<AppRole> FindByName(string roleName);
    }
}
