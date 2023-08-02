using AutoMapper;

namespace SiteManagement.Business.Services.Commands.ExpenseType.Insert
{
    public class InsertExpenseTypeMapper : Profile
    {
        public InsertExpenseTypeMapper()
        {
            CreateMap<InsertExpenseTypeCommandRequestModel, Data.Entity.ExpenseType>();
        }
    }
}
