using SiteManagement.Core.Notification.Email.Model;

namespace SiteManagement.Core.Notification.Email.Abstract
{
    public interface ISmtpHelper
    {
        void SendMail(MailParameters mailParams);
    }
}
