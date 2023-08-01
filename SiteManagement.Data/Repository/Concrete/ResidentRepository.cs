using SiteManagement.Data.Context;
using SiteManagement.Data.Core.Repository.Concrete;
using SiteManagement.Data.Entity;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Data.Repository.Concrete
{
    public class ResidentRepository : Repository<Resident, EfDbContext>, IResidentRepository
    {
        public ResidentRepository(EfDbContext context) : base(context)
        {
        }
    }
}
