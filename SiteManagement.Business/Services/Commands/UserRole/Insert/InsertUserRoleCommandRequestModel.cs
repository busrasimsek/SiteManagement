using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.UserRole.Insert
{
    public class InsertUserRoleCommandRequestModel : IRequest<ResponseItem>
    {
        public string Type { get; set; }
    }
}
