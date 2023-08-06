using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Expense.Update
{
    public class UpdateExpenseMapper : Profile
    {
        public UpdateExpenseMapper()
        {
            CreateMap<UpdateExpenseCommandRequestModel, Data.Entity.Expense>();
        }
    }
}
