using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Future.Commands.User.Insert
{
    
    public class InsertUserMapper : Profile
    {
        public InsertUserMapper()
        {
            CreateMap<InsertUserCommandRequestModel, Data.Entity.User>();
        }
    }
}
