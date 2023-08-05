using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Expense.GetExpenseById
{
    public class GetExpenseByIdMapper : Profile
    {
        public GetExpenseByIdMapper()
        {
            CreateMap<Data.Entity.Expense, GetExpenseByIdQueryResponseModel>();
        }
    }
}
