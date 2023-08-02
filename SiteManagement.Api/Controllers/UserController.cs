using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.User.Insert;
using SiteManagement.Business.Services.Commands.User.Update;
using SiteManagement.Business.Services.Queries.User.GetAll;
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
        public async Task<IActionResult> Insert
            ([FromBody] InsertUserCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }
    }
}
