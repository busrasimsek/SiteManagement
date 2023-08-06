using AutoMapper;

namespace SiteManagement.Business.Services.Commands.UserRole.Insert
{
    public class InsertUserRoleMapper : Profile
    {
        public InsertUserRoleMapper()
        {
            CreateMap<InsertUserRoleCommandRequestModel, Data.Entity.User>();
        }
    }
}
