using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Home.GetAll
{
    public class GetAllHomeMapper : Profile
    {
        public GetAllHomeMapper()
        {
            CreateMap<Data.Entity.Home, GetAllHomeQueryResponseModel>();
        }
    }
}