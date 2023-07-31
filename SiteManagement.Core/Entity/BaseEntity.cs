namespace SiteManagement.Core.Entity
{
    public class BaseEntity<TType>
    {
        public TType Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
