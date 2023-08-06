using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Home.Insert;
using SiteManagement.Business.Services.Commands.Home.Update;
using SiteManagement.Business.Services.Queries.Home.GetHomeByApartmentId;
using SiteManagement.Business.Services.Queries.Home.GetHomeById;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll([FromQuery] GetAllHomeQueryRequestModel requestModel)
        //    => Handle(await _mediator.Send(requestModel));

        
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetHomeById([FromRoute] int id)
            => Handle(await _mediator.Send(new GetHomeByIdQueryRequestModel { Id = id }));
       
        [HttpGet("GetByApartmentId")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetHomeByApartmentId([FromQuery] GetHomeByApartmentIdQueryRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Insert([FromBody] InsertHomeCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateHomeCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }
    }
}
