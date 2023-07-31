using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Future.Queries.User.GetAll;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserQueryRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));
    }
}
