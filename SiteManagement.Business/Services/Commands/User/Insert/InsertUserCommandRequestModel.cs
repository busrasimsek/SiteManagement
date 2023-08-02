using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.User.Insert
{
    public class InsertUserCommandRequestModel : IRequest<ResponseItem>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
    }
}
