using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Home.GetHomeById
{
    public class GetHomeByIdMapper : Profile
    {
        public GetHomeByIdMapper()
        {
            CreateMap<Data.Entity.Home, GetHomeByIdQueryResponseModel>();
        }
    }
}
