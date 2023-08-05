using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Expense.GetExpenseById
{
    public class GetExpenseByIdQueryRequestModel : IRequest<ResponseItem<GetExpenseByIdQueryResponseModel>>
    {
        public int Id { get; set; }
    }
}
