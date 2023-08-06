using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Home.GetHomeByApartmentId
{
    public class GetHomeByApartmentIdMapper : Profile
    {
        public GetHomeByApartmentIdMapper()
        {
            CreateMap<Data.Entity.Home, GetHomeByApartmentIdQueryResponseModel>();
        }
    }
}
