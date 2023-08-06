using SiteManagement.Data.Context;
using SiteManagement.Data.Core.Repository.Concrete;
using SiteManagement.Data.Entity;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Data.Repository.Concrete
{
    public class UserRoleRepository : Repository<UserRole, EfDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(EfDbContext context) : base(context)
        {
        }
    }
}
