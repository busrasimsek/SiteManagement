using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Services.Queries.Resident.GetById
{
    public class GetResidentByHomeIdMapper : Profile
    {
        public GetResidentByHomeIdMapper()
        {
            CreateMap<Data.Entity.Resident,GetResidentByHomeIdQueryResponseModel>();
        }
    }
}
