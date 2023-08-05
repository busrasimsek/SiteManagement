using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Vehicle.GetVehicleByUserId
{
    public class GetVehicleByUserIdQueryRequestModel : IRequest<ResponseItem<List<GetVehicleByUserIdQueryResponseModel>>>
    {
        public int UserId { get; set; }
    }
}
