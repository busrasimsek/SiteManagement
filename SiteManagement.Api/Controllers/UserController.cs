using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.User.Delete;
using SiteManagement.Business.Services.Commands.User.Insert;
using SiteManagement.Business.Services.Commands.User.Update;
using SiteManagement.Business.Services.Queries.User.GetAll;
using SiteManagement.Business.Services.Queries.User.GetUserById;
using SiteManagement.Business.Services.Queries.Vehicle.GetVehicleById;
using SiteManagement.Core.Controller;
using System.Data;

namespace SiteManagement.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
            => Handle(await _mediator.Send(new GetUserByIdQueryRequestModel { Id = id }));

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserQueryRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Insert([FromBody] InsertUserCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete([FromRoute] int id)
            => Handle(await _mediator.Send(new DeleteUserCommandRequestModel { Id = id }));

    }
}
