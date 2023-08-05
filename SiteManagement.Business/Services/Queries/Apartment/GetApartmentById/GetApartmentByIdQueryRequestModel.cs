using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Apartment.GetApartmentById
{
    public class GetApartmentByIdQueryRequestModel : IRequest<ResponseItem<GetApartmentByIdQueryResponseModel>>
    {
        public int Id { get; set; }
    }
}
