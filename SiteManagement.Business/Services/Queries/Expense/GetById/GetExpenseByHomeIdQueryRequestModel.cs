using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Expense.GetById
{
    public class GetExpenseByHomeIdQueryRequestModel : IRequest<ResponseItem<List<GetExpenseByHomeIdQueryResponseModel>>>
    {
        public int HomeId { get; set; }

    }
}
