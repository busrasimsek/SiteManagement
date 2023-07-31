using SiteManagement.Data.Core.Repository.Abstract;
using SiteManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Repository.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
