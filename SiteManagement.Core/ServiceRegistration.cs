using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Core.Identity;

namespace SiteManagement.Core
{
    public static class ServiceRegistration
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();

        }
    }
}
