using SiteManagement.Data.Context;
using SiteManagement.Data.Core.Repository.Concrete;
using SiteManagement.Data.Entity;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Data.Repository.Concrete
{
    public class ExpenseTypeRepository : Repository<ExpenseType, EfDbContext>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(EfDbContext context) : base(context)
        {
        }
    }
}
