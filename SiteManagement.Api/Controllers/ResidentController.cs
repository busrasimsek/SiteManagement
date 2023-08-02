using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Resident.Insert;
using SiteManagement.Business.Services.Queries.Resident.GetById;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{

    public class ResidentController : BaseController
    {
        public ResidentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetByHomeId")]
        public async Task<IActionResult> GetById([FromQuery] GetResidentByHomeIdQueryRequestModel requestModel)
         => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertResidentCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));
    }
}
