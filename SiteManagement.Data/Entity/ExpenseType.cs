using SiteManagement.Core.Entity;

namespace SiteManagement.Data.Entity
{
    public class ExpenseType : BaseEntity
    {
        public string TypeName { get; set; }
        public string? Description { get; set; }
        public int ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}
