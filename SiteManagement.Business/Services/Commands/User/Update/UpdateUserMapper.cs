using AutoMapper;

namespace SiteManagement.Business.Services.Commands.User.Update
{
    public class UpdateUserMapper : Profile
    {
        public UpdateUserMapper()
        {
            CreateMap<UpdateUserCommandRequestModel, Data.Entity.User>();
        }
    }
}
