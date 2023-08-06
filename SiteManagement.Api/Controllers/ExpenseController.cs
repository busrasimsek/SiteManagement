using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Apartment.Insert;
using SiteManagement.Business.Services.Commands.Apartment.Update;
using SiteManagement.Business.Services.Commands.Expense.Insert;
using SiteManagement.Business.Services.Commands.Expense.Update;
using SiteManagement.Business.Services.Queries.Apartment.GetApartmentById;
using SiteManagement.Business.Services.Queries.Expense.GetExpenseByHomeId;
using SiteManagement.Business.Services.Queries.Expense.GetExpenseById;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class ExpenseController : BaseController
    {
        public ExpenseController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(Roles = "User,Manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById([FromRoute] int id)
            => Handle(await _mediator.Send(new GetExpenseByIdQueryRequestModel { Id = id }));

        [HttpGet("GetByHomeId")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetExpenseByHomeId([FromQuery] GetExpenseByHomeIdQueryRequestModel requestModel)
          => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Insert([FromBody] InsertExpenseCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateExpenseCommandRequestModel requestModel)
        {
            requestModel.Id = id;
            return Handle(await _mediator.Send(requestModel)); ;
        }
    }
}
