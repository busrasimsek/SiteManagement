using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Resident.Update
{
    public class UpdateResidentMapper : Profile
    {
        public UpdateResidentMapper()
        {
            CreateMap<UpdateResidentCommandRequestModel, Data.Entity.Resident>();
        }
    }
}
