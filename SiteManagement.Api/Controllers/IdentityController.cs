using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Apartment.Insert;
using SiteManagement.Business.Services.Commands.Identity.Login;
using SiteManagement.Business.Services.Queries.Apartment.GetById;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class IdentityController : BaseController
    {
        public IdentityController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequestModel requestModel)
          => Handle(await _mediator.Send(requestModel));
    }
}
