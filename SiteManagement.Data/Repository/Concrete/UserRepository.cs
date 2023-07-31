using SiteManagement.Data.Context;
using SiteManagement.Data.Core.Repository.Concrete;
using SiteManagement.Data.Entity;
using SiteManagement.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Repository.Concrete
{
    public class UserRepository : Repository<User, EfDbContext>, IUserRepository
    {
        public UserRepository(EfDbContext context) : base(context)
        {
        }
    }
}
