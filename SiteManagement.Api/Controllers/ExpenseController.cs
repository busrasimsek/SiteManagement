using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.Expense.Insert;
using SiteManagement.Business.Services.Queries.Expense.GetExpenseByHomeId;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class ExpenseController : BaseController
    {
        public ExpenseController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetByHomeId")]
        public async Task<IActionResult> GetExpenseByHomeId([FromQuery] GetExpenseByHomeIdQueryRequestModel requestModel)
          => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertExpenseCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));
    }
}
