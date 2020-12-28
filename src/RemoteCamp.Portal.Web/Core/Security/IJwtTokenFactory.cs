using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace RemoteCamp.Portal.Web.Core.Security
{
    public interface IJwtTokenFactory
    {
        string Create(ClaimsIdentity claimsIdentity);

        string Refresh(string token);
    }
}