using JWT.Entities.Concrete;

namespace JWT.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(AppUser appUser, List<AppRole> roles);
    }
}
