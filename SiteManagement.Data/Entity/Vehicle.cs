using SiteManagement.Core.Entity;

namespace SiteManagement.Data.Entity
{
    public class Vehicle: BaseEntity
    {
        public int UserId { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public virtual User User { get; set; }
    }
}
