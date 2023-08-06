using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Apartment.Delete;
using SiteManagement.Business.Services.Commands.Apartment.Insert;
using SiteManagement.Business.Services.Commands.Apartment.Update;
using SiteManagement.Business.Services.Queries.Apartment.GetApartmentById;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class ApartmentController : BaseController
    {
        public ApartmentController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(Roles = "User,Manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApartmentById([FromRoute] int id)
            => Handle(await _mediator.Send(new GetApartmentByIdQueryRequestModel { Id = id }));

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertApartmentCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateApartmentCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete([FromRoute] int id)
         => Handle(await _mediator.Send(new DeleteApartmentCommandRequestModel { Id = id }));
    }
}
