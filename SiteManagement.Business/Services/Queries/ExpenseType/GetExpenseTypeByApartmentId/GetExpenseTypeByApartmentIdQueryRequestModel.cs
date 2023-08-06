using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeByApartmentId
{
    public class GetExpenseTypeByApartmentIdQueryRequestModel : IRequest<ResponseItem<List<GetExpenseTypeByApartmentIdQueryResponseModel>>>
    {
        public int ApartmentId { get; set; }
    }
}
