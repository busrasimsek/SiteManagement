using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Home.Insert;
using SiteManagement.Business.Services.Queries.Home.GetHomeByApartmentId;
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

        [HttpGet("GetByApartmentId")]
        public async Task<IActionResult> GetHomeByApartmentId([FromQuery] GetHomeByApartmentIdQueryRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertHomeCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));
    }
}
