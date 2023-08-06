using AutoMapper;

namespace SiteManagement.Business.Services.Queries.User.GetAll
{
    public class GetAllUserMapper : Profile
    {
        public GetAllUserMapper()
        {
            CreateMap<Data.Entity.User, GetAllUserQueryResponseModel>();
        }
    }
}
