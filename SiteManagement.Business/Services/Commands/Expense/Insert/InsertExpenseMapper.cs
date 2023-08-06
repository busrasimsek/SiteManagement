using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Expense.Insert
{
    public class InsertExpenseMapper : Profile
    {
        public InsertExpenseMapper()
        {
            CreateMap<InsertExpenseCommandRequestModel, Data.Entity.Expense>();
        }
    }
}
