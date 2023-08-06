using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.UserRole.Delete;
using SiteManagement.Business.Services.Commands.UserRole.Insert;
using SiteManagement.Business.Services.Commands.UserRole.Update;
using SiteManagement.Business.Services.Queries.UserRole.GetUserRoleById;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{

    public class UserRoleController : BaseController
    {
        public UserRoleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetUserRoleById([FromRoute] int id)
            => Handle(await _mediator.Send(new GetUserRoleByIdQueryRequestModel { Id = id }));

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Insert([FromBody] InsertUserRoleCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRoleCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        => Handle(await _mediator.Send(new DeleteUserRoleCommandRequestModel { Id = id }));
    }
}
