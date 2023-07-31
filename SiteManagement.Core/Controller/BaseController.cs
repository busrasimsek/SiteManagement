using MediatR;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Core.Response;

namespace SiteManagement.Core.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected ActionResult Handle<T>(ResponseItem<T> response)
        {
            if (response.Status == "OK")
            {
                var x = Ok(BaseResponseModel.Ok(response, HttpContext.TraceIdentifier));
                return x;
            }
            else
                return BadRequest(BaseResponseModel.BadRequest(ResponseMessageToString.ResponseMessageToStr(response.Messages), HttpContext.TraceIdentifier));
        }
    }
}
