using AutoMapper;

namespace SiteManagement.Business.Services.Queries.User.GetUserById
{
    public class GetUserByIdMapper : Profile
    {
        public GetUserByIdMapper()
        {
            CreateMap<Data.Entity.User, GetUserByIdQueryResponseModel>();
        }
    }
}
