
namespace SiteManagement.Core.Identity
{
    public interface ITokenService
    {
        string GenerateToken(string userName, string role);
    }
}
