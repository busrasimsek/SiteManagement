using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Apartment.Insert
{
    public class InsertApartmentMapper : Profile
    {
        public InsertApartmentMapper()
        {
            CreateMap<InsertApartmentCommandRequestModel, Data.Entity.Apartment>();
        }
    }
}
