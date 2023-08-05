using AutoMapper;

namespace SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeByApartmentId
{
    public class GetExpenseTypeByApartmentIdMapper : Profile
    {
        public GetExpenseTypeByApartmentIdMapper()
        {
            CreateMap<Data.Entity.ExpenseType, GetExpenseTypeByApartmentIdQueryResponseModel>();
        }
    }
}
