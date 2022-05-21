using JWT.Business.Interfaces;
using JWT.Business.StringInfos;
using JWT.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JWT.Business.Concrete
{
    public class JwtManager : IJwtService
    {
        public string GenerateJwtToken(AppUser appUser, List<AppRole> roles)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

            var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(issuer: JwtInfo.Issuer, audience: JwtInfo.Audience,
                notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(JwtInfo.TokenExpration),
                signingCredentials: signinCredentials, claims: GetClaims(appUser, roles));

            var handler = new JwtSecurityTokenHandler(); //IdentityModel.Tokens.Jwt Nuget Package

            return handler.WriteToken(jwtSecurityToken);
        }

        private List<Claim> GetClaims(AppUser appUser, List<AppRole> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));

            if (roles == null)
            {
                return null;
            }
            if (roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }
            return claims;
        }
    }
}
