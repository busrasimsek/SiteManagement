using SiteManagement.Core.Entity;

namespace SiteManagement.Data.Entity
{
    public class Message : BaseEntity
    {
        public int SourceUserId { get; set; }
        public int DestinationUserId { get; set; }
        public string Messages { get; set; }
        public DateTime Date { get; set; }
        public bool IsSeen { get; set; }
        public virtual User SourceUser { get; set; }
        public virtual User DestinationUser { get; set;}
    }
}
