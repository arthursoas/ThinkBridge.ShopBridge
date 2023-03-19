using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThinkBridge.ShopBridge.Domain.Requests.Item;

namespace ThinkBridge.ShopBridge.WebAPI.Controllers
{
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        public ItemController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor)
            : base(mediator, httpContextAccessor)
        {
        }

        [HttpGet]
        public async Task<ActionResult> ListItemsAsync([FromQuery] GetItemsRequest request, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ListItemAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItemAsync([FromBody] CreateItemRequest request, CancellationToken cancellationToken)
        {
            return BuildResponse(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync([FromRoute] int id, [FromBody] UpdateItemRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;
            return BuildResponse(await Mediator.Send(request, cancellationToken));
        }
    }
}
