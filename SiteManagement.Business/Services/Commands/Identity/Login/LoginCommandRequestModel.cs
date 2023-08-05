using MediatR;
using SiteManagement.Core.Response;
using SiteManagement.Core.Response.TokenResponse;

namespace SiteManagement.Business.Services.Commands.Identity.Login
{
    public class LoginCommandRequestModel : IRequest<ResponseItem<Token>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
