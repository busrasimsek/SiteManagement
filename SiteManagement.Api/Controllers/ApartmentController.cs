using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Apartment.Insert;
using SiteManagement.Business.Services.Queries.Apartment.GetById;
using SiteManagement.Core.Controller;
using SiteManagement.Data.Entity;
using System.Security.Claims;

namespace SiteManagement.Api.Controllers
{
    public class ApartmentController : BaseController
    {
        public ApartmentController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(Roles = "User,Manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
            => Handle(await _mediator.Send(new GetApartmentByIdQueryRequestModel { Id = id }));

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertApartmentCommandRequestModel requestModel)
          => Handle(await _mediator.Send(requestModel));
    }
}
