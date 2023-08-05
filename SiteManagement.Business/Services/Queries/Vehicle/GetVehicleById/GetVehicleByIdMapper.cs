using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Vehicle.GetVehicleById
{
    public class GetVehicleByIdMapper : Profile
    {
        public GetVehicleByIdMapper()
        {
            CreateMap<Data.Entity.Vehicle, GetVehicleByIdQueryResponseModel>();
        }
    }
}
