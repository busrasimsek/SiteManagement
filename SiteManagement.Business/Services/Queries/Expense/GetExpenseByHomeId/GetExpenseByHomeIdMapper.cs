using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Expense.GetExpenseByHomeId
{
    public class GetExpenseByHomeIdMapper : Profile
    {
        public GetExpenseByHomeIdMapper()
        {
            CreateMap<Data.Entity.Expense, GetExpenseByHomeIdQueryResponseModel>();
        }
    }
}