using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Core.Repository.Abstract
{
    public interface IRepository<TEntity> : IBaseRepository where TEntity : class
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        List<TEntity> Delete(List<TEntity> entities);
        IQueryable<TEntity> Query();
    }
}
