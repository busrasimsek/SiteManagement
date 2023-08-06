using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.Identity.Login
{
    public class LoginCommandRequestModel : IRequest<ResponseItem<LoginCommandResponseModel>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
