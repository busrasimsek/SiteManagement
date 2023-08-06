using SiteManagement.Data.Context;
using SiteManagement.Data.Core.Repository.Concrete;
using SiteManagement.Data.Entity;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Data.Repository.Concrete
{
    public class ApartmentRepository : Repository<Apartment, EfDbContext>, IApartmentRepository
    {
        public ApartmentRepository(EfDbContext context) : base(context)
        {
        }
    }
}
