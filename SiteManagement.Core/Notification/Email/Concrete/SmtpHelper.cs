using SiteManagement.Core.Notification.Email.Abstract;
using SiteManagement.Core.Notification.Email.Model;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SiteManagement.Core.Notification.Email.Concrete
{
    public class SmtpHelper : ISmtpHelper
    {
        private readonly SmtpConfiguration _smtpConfiguration;

        public SmtpHelper(SmtpConfiguration smtpConfiguration)
        {
            _smtpConfiguration = smtpConfiguration;
        }
        public void SendMail(MailParameters mailParams)
        {
            var smtpServer = new SmtpClient(_smtpConfiguration.Host, _smtpConfiguration.Port);

            var basicAuthenticationInfo = new NetworkCredential(_smtpConfiguration.UserName, _smtpConfiguration.Password);
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = basicAuthenticationInfo;
            smtpServer.EnableSsl = _smtpConfiguration.EnableSSL;

            var eMail = new MailMessage();
            eMail.To.Clear();
            eMail.From = new MailAddress(_smtpConfiguration.UserName, mailParams.MailHeader);

            foreach (var to in mailParams.MailTo.Where(to => !string.IsNullOrEmpty(to)))
            {
                eMail.To.Add(to);
            }
            foreach (var bcc in mailParams.MailBCC.Where(bcc => !string.IsNullOrEmpty(bcc)))
            {
                eMail.Bcc.Add(bcc);
            }
            foreach (var cc in mailParams.MailCC.Where(cc => !string.IsNullOrEmpty(cc)))
            {
                eMail.CC.Add(cc);
            }

            eMail.BodyEncoding = Encoding.UTF8;
            eMail.Subject = mailParams.MailSubject;
            eMail.IsBodyHtml = true;
            eMail.Body = mailParams.MailBody + Environment.NewLine;

            foreach (var attachment in mailParams.Attachments)
            {
                eMail.Attachments.Add(attachment);
            }

            smtpServer.Send(eMail);
        }

    }
}
