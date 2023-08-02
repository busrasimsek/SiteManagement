using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Apartment.GetById
{
    public class GetApartmentByIdMapper : Profile
    {
        public GetApartmentByIdMapper()
        {
            CreateMap<Data.Entity.Apartment, GetApartmentByIdQueryResponseModel>();
        }
    }
}
