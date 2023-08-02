using SiteManagement.Core.Entity;

namespace SiteManagement.Data.Entity
{
    public class Resident : BaseEntity //Daire sakinleri
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }
        public bool? Sex { get; set; }
        public int HomeId { get; set; }
        public virtual Home Home { get; set; }
    }
}
