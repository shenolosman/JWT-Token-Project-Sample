using JWT.DataAccess.Concrete.EntityFrameworkCore.Context;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace JWT.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public async Task<List<AppRole>> GetRolesByUserName(string userName)
        {
            await using var context = new JwtContext();
            return await context.AppUsers
                .Join(context.AppUserRoles, entryPoint => entryPoint.Id, ur => ur.AppUserId, (user, userRole) => new { user, userRole }
                )
                .Join(context.AppRoles, combinedTwoTable => combinedTwoTable.userRole.AppRoleId, roleTable => roleTable.Id, (twoTable, role) => new
                { twoTable.user, role, twoTable.userRole })
                .Where(x => x.user.UserName == userName)
                .Select(x => new AppRole
                {
                    Id = x.role.Id,
                    Name = x.role.Name
                })
                .ToListAsync();
        }
    }
}
