using AutoMapper;

namespace SiteManagement.Business.Services.Commands.Home.Insert
{
    public class InsertHomeMapper : Profile
    {
        public InsertHomeMapper()
        {
            CreateMap<InsertHomeCommandRequestModel, Data.Entity.Home>();
        }
    }
}
