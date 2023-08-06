using SiteManagement.Data.Context;
using SiteManagement.Data.Core.Repository.Concrete;
using SiteManagement.Data.Entity;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Data.Repository.Concrete
{
    public class ExpenseRepository : Repository<Expense, EfDbContext>, IExpenseRepository
    {
        public ExpenseRepository(EfDbContext context) : base(context)
        {
        }
    }
}
