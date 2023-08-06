using AutoMapper;

namespace SiteManagement.Business.Services.Commands.UserRole.Update
{
    public class UpdateUserRoleMapper : Profile
    {
        public UpdateUserRoleMapper()
        {
            CreateMap<UpdateUserRoleCommandRequestModel, Data.Entity.UserRole>();
        }
    }
}
