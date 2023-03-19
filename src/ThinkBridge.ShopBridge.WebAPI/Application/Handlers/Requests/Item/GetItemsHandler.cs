using MediatR;
using ThinkBridge.ShopBridge.Data.Repositiories;
using ThinkBridge.ShopBridge.Domain.Requests.Item;
using ThinkBridge.ShopBridge.Domain.Responses;

namespace ThinkBridge.ShopBridge.WebAPI.Application.Handlers.Requests.Item
{
    public class GetItemsHandler : HandlerBase, IRequestHandler<GetItemsRequest, ResponseBase<GetItemResponse[]>>
    {
        private readonly IItemRepository _itemRepository;

        public GetItemsHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ResponseBase<GetItemResponse[]>> Handle(GetItemsRequest request, CancellationToken cancellationToken)
        {
            var response = new ResponseBase<GetItemResponse[]>();
            var items = await _itemRepository.SelectItemsAsync(cancellationToken);

            response.Payload = items
                .Select(i => GetItemResponse.FromItem(i))
                .ToArray();

            return response;
        }
    }
}
