using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeById
{
    public class GetExpenseTypeByIdQueryRequestModel : IRequest<ResponseItem<GetExpenseTypeByIdQueryResponseModel>>
    {
        public int Id { get; set; }
    }
}
