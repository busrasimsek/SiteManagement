using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Future.Commands.User.Insert;
using SiteManagement.Business.Future.Commands.User.Update;
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

        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] InsertUserCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }
    }
}
