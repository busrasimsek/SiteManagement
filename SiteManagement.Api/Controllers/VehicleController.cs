using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Vehicle.Delete;
using SiteManagement.Business.Services.Commands.Vehicle.Insert;
using SiteManagement.Business.Services.Commands.Vehicle.Update;
using SiteManagement.Business.Services.Queries.Vehicle.GetVehicleById;
using SiteManagement.Business.Services.Queries.Vehicle.GetVehicleByUserId;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class VehicleController : BaseController
    {
        public VehicleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetVehicleById([FromRoute] int id)
        => Handle(await _mediator.Send(new GetVehicleByIdQueryRequestModel { Id = id }));

        [HttpGet("GetByUserId")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetVehicleByUserId([FromQuery] GetVehicleByUserIdQueryRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Insert([FromBody] InsertVehicleCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateVehicleCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete([FromRoute] int id)
         => Handle(await _mediator.Send(new DeleteVehicleCommandRequestModel { Id = id }));
    }
}
