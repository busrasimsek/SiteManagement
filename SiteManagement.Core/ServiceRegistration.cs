using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Core.Identity;
using SiteManagement.Core.Notification.Email.Abstract;
using SiteManagement.Core.Notification.Email.Concrete;
using SiteManagement.Core.Notification.Email.Model;

namespace SiteManagement.Core
{
    public static class ServiceRegistration
    {
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            var smtpConfiguration = configuration.GetSection(nameof(SmtpConfiguration)).Get<SmtpConfiguration>();
            services.AddSingleton(smtpConfiguration);
            services.AddScoped<ISmtpHelper, SmtpHelper>();
        }
    }
}
