using AutoMapper;

namespace SiteManagement.Business.Services.Commands.User.Insert
{
    public class InsertUserMapper : Profile
    {
        public InsertUserMapper()
        {
            CreateMap<InsertUserCommandRequestModel, Data.Entity.User>();
        }
    }
}
