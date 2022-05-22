using JWT.Business.Interfaces;
using JWT.Business.StringInfos;
using JWT.Entities.Concrete;

namespace JWT.WebApi
{
    public class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            //i have to write my own role create method cause of i didnt use identity package

            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);
            if (adminRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }

            var memberRole = await appRoleService.FindByName(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByUserName("admin");
            if (adminUser == null)
            {
                await appUserService.Add(new AppUser
                {
                    UserName = "admin",
                    Password = "1",
                    FullName = "admin"
                });


                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var admin = await appUserService.FindByUserName("admin");
                await appUserRoleService.Add(new AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });
            }
        }
    }
}
