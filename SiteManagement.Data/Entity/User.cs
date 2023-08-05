using SiteManagement.Core.Entity;

namespace SiteManagement.Data.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public virtual UserRole UserRole{ get; set; }
    }
}
