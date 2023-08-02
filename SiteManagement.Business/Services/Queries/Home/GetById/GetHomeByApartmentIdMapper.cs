using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Home.GetById
{
    public class GetHomeByApartmentIdMapper : Profile
    {
        public GetHomeByApartmentIdMapper()
        {
            CreateMap<Data.Entity.Home, GetHomeByApartmentIdQueryResponseModel>();
        }
    }
}
