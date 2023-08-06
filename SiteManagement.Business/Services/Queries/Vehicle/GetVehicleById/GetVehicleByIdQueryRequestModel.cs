using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Vehicle.GetVehicleById
{
    public class GetVehicleByIdQueryRequestModel : IRequest<ResponseItem<GetVehicleByIdQueryResponseModel>>
    {
        public int Id { get; set; }
    }
}
