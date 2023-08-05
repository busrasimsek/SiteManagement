using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Apartment.GetApartmentById
{
    public class GetApartmentByIdMapper : Profile
    {
        public GetApartmentByIdMapper()
        {
            CreateMap<Data.Entity.Apartment, GetApartmentByIdQueryResponseModel>();
        }
    }
}
