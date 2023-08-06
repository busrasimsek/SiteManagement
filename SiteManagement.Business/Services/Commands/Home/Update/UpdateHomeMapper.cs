using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Home.Update
{
    public class UpdateHomeMapper : Profile
    {
        public UpdateHomeMapper()
        {
            CreateMap<UpdateHomeCommandRequestModel, Data.Entity.Home>();
        }
    }
}
