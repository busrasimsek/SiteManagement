using SiteManagement.Core.Response.TokenResponse;

namespace SiteManagement.Core.Identity
{
    public interface ITokenService
    {
        Token GenerateToken(int second, string userName, string role);
    }
}
