using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Message.Insert;
using SiteManagement.Business.Services.Commands.Message.SeenAndGetByDestionationId;
using SiteManagement.Business.Services.Queries.Message.GetMessageBySourceId;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class MessageController : BaseController
    {
        public MessageController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> Insert([FromBody] InsertMessageCommandRequestModel requestModel)
          => Handle(await _mediator.Send(requestModel));

        [HttpGet]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetMessageBySourceId([FromQuery] GetMessageBySourceIdQueryRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPost("SeenAndGetByDestinationMessage")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> SeenAndGetByDestinationMessage([FromQuery] SeenAndGetByDestionationIdCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));
    }
}
