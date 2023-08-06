using System.Net.Mail;

namespace SiteManagement.Core.Notification.Email.Model
{
    public class MailParameters
    {
        public List<string> MailTo { get; set; } = new();
        public List<string> MailBCC { get; set; } = new();
        public List<string> MailCC { get; set; } = new();
        public string MailHeader { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public List<Attachment> Attachments { get; set; } = new();
    }
}
