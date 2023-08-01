using MediatR;
using SiteManagement.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Future.Commands.User.Insert
{
    public class InsertUserCommandRequestModel : IRequest<ResponseItem>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
    }
}
