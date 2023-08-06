using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Vehicle.Update
{
    public class UpdateVehicleMapper : Profile
    {
        public UpdateVehicleMapper()
        {
            CreateMap<UpdateVehicleCommandRequestModel, Data.Entity.Vehicle>();
        }
    }
}
