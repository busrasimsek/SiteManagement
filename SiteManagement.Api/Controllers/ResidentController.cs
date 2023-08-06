using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Resident.Insert;
using SiteManagement.Business.Services.Commands.Resident.Update;
using SiteManagement.Business.Services.Queries.Resident.GetResidentByHomeId;
using SiteManagement.Business.Services.Queries.Resident.GetResidentById;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{

    public class ResidentController : BaseController
    {
        public ResidentController(IMediator mediator) : base(mediator)
        {
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetResidentById([FromRoute] int id)
          => Handle(await _mediator.Send(new GetResidentByIdQueryRequestModel { Id = id }));

        [HttpGet("GetByHomeId")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetResidentByHomeId([FromQuery] GetResidentByHomeIdQueryRequestModel requestModel)
         => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Insert([FromBody] InsertResidentCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateResidentCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }
    }
}
