using AutoMapper;

namespace SiteManagement.Business.Services.Queries.Resident.GetResidentById
{
    public class GetResidentByIdMapper : Profile
    {
        public GetResidentByIdMapper()
        {
            CreateMap<Data.Entity.Resident, GetResidentByIdQueryResponseModel>();
        }
    }
}
