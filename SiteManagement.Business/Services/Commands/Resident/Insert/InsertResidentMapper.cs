using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Resident.Insert
{
    public class InsertResidentMapper : Profile
    {
        public InsertResidentMapper()
        {
            CreateMap<InsertResidentCommandRequestModel, Data.Entity.Resident>();
        }
    }
}
