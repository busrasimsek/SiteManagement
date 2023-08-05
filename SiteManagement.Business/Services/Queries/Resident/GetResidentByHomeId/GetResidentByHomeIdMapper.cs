using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Resident.GetResidentByHomeId
{
    public class GetResidentByHomeIdMapper : Profile
    {
        public GetResidentByHomeIdMapper()
        {
            CreateMap<Data.Entity.Resident,GetResidentByHomeIdQueryResponseModel>();
        }
    }
}
