using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThinkBridge.ShopBridge.Domain.Responses;

namespace ThinkBridge.ShopBridge.WebAPI.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected readonly IMediator Mediator;
        protected readonly IHttpContextAccessor HttpContextAccessor;

        public ControllerBase(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor)
        {
            Mediator = mediator;
            HttpContextAccessor = httpContextAccessor;
        }

        protected ActionResult BuildResponse<T>(ResponseBase<T> response)
        {
            if (response.ValidationResult.Errors.Any())
            {
                return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "messages", response.ValidationResult.Errors.Select(e => e.ErrorMessage).ToArray() }
                }));
            }

            return Ok(response.Payload);
        }
    }
}
