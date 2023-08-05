using AutoMapper;

namespace SiteManagement.Business.Services.Commands.ExpenseType.Update
{
    public class UpdateExpenseTypeMapper : Profile
    {
        public UpdateExpenseTypeMapper()
        {
            CreateMap<UpdateExpenseTypeCommandRequestModel, Data.Entity.ExpenseType>();
        }
    }
}
