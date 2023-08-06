using SiteManagement.Core.Entity;

namespace SiteManagement.Data.Entity
{
    public class Home : BaseEntity
    {
        public int UserId { get; set; }
        public int Floor { get; set; }
        public string No { get; set; }
        public string HomeType { get; set; }
        public bool? Status { get; set; }
        public int ApartmentId { get; set; }
        public bool? IsTenant { get; set; } //kiralik mı sahibi mi
        public virtual User User { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}
