using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Vehicle.GetVehicleByUserId
{
    public class GetVehicleByUserIdMapper : Profile
    {
        public GetVehicleByUserIdMapper()
        {
            CreateMap<Data.Entity.Vehicle, GetVehicleByUserIdQueryResponseModel>();
        }
    }
}
