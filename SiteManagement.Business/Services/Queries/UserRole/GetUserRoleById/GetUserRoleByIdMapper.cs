using AutoMapper;

namespace SiteManagement.Business.Services.Queries.UserRole.GetUserRoleById
{
    public class GetUserRoleByIdMapper : Profile
    {
        public GetUserRoleByIdMapper()
        {
            CreateMap<Data.Entity.UserRole, GetUserRoleByIdQueryResponseModel>();
        }
    }
}
