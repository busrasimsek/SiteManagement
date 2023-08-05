using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Home.GetHomeByApartmentId
{
    public class GetHomeByApartmentIdQueryRequestModel : IRequest<ResponseItem<List<GetHomeByApartmentIdQueryResponseModel>>>
    {
        public int ApartmentId { get; set; }
    }
}
