using AutoMapper;

namespace SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeById
{
    public class GetExpenseTypeByIdMapper : Profile
    {
        public GetExpenseTypeByIdMapper()
        {
            CreateMap<Data.Entity.ExpenseType, GetExpenseTypeByIdQueryResponseModel>();
        }
    }
}
