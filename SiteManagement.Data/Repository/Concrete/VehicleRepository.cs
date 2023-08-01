using SiteManagement.Data.Context;
using SiteManagement.Data.Core.Repository.Concrete;
using SiteManagement.Data.Entity;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Data.Repository.Concrete
{
    public class VehicleRepository : Repository<Vehicle, EfDbContext>, IVehicleRepository
    {
        public VehicleRepository(EfDbContext context) : base(context)
        {
        }
    }
}
