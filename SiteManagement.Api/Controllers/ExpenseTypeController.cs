using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.ExpenseType.Insert;
using SiteManagement.Business.Services.Commands.ExpenseType.Update;
using SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeByApartmentId;
using SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeById;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class ExpenseTypeController : BaseController
    {
        public ExpenseTypeController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(Roles = "User,Manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseTypeById([FromRoute] int id)
            => Handle(await _mediator.Send(new GetExpenseTypeByIdQueryRequestModel { Id = id }));

        [HttpGet("GetByApartmentId")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetExpenseTypeByApartmentId([FromQuery] GetExpenseTypeByApartmentIdQueryRequestModel requestModel)
          => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Insert([FromBody] InsertExpenseTypeCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateExpenseTypeCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }
    }
}
