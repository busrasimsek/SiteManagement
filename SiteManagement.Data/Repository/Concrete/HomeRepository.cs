using SiteManagement.Data.Context;
using SiteManagement.Data.Core.Repository.Concrete;
using SiteManagement.Data.Entity;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Data.Repository.Concrete
{
    public class HomeRepository : Repository<Home, EfDbContext>, IHomeRepository
    {
        public HomeRepository(EfDbContext context) : base(context)
        {
        }
    }
}
