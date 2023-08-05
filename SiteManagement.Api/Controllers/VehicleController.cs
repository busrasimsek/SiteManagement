using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Vehicle.Insert;
using SiteManagement.Business.Services.Queries.Vehicle.GetVehicleByUserId;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class VehicleController : BaseController
    {
        public VehicleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetVehicleByUserId([FromQuery] GetVehicleByUserIdQueryRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertVehicleCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));
    }
}
