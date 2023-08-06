using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Vehicle.Insert
{
    public class InsertVehicleMapper : Profile
    {
        public InsertVehicleMapper()
        {
            CreateMap<InsertVehicleCommandRequestModel, Data.Entity.Vehicle>();
        }
    }
}
