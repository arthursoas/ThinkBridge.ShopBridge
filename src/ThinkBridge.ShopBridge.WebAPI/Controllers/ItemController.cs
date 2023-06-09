﻿using MediatR;
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
        public async Task<ActionResult> ListItemsAsync(CancellationToken cancellationToken)
        {
            var request = new GetItemsRequest();
            return BuildResponse(await Mediator.Send(request, cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItemAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var request = new GetItemRequest { Id = id };
            return BuildResponse(await Mediator.Send(request, cancellationToken));
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
