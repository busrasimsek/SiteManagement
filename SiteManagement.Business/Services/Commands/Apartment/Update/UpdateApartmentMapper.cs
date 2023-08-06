using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Apartment.Update
{
    public class UpdateApartmentMapper : Profile
    {
        public UpdateApartmentMapper()
        {
            CreateMap<UpdateApartmentCommandRequestModel, Data.Entity.Apartment>();
        }
    }
}
