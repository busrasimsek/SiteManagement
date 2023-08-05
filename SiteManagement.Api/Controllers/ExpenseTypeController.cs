using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Business.Services.Commands.ExpenseType.Insert;
using SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeByApartmentId;
using SiteManagement.Core.Controller;

namespace SiteManagement.Api.Controllers
{
    public class ExpenseTypeController : BaseController
    {
        public ExpenseTypeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetByApartmentId")]
        public async Task<IActionResult> GetExpenseTypeByApartmentId([FromQuery] GetExpenseTypeByApartmentIdQueryRequestModel requestModel)
          => Handle(await _mediator.Send(requestModel));

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertExpenseTypeCommandRequestModel requestModel)
            => Handle(await _mediator.Send(requestModel));
    }
}
