using JWT.Entities.Interfaces;

namespace JWT.Entities.Token
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }
    }
}
