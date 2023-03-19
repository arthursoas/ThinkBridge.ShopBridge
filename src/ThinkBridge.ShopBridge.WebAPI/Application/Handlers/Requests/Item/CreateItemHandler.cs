using MediatR;
using ThinkBridge.ShopBridge.Data.Repositiories;
using ThinkBridge.ShopBridge.Domain.Requests.Item;
using ThinkBridge.ShopBridge.Domain.Responses;
using ItemEntity = ThinkBridge.ShopBridge.Domain.Entities.Item;

namespace ThinkBridge.ShopBridge.WebAPI.Application.Handlers.Requests.Item
{
    public class CreateItemHandler : HandlerBase, IRequestHandler<CreateItemRequest, ResponseBase<GetItemResponse>>
    {
        private readonly IItemRepository _itemRepository;

        public CreateItemHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ResponseBase<GetItemResponse>> Handle(CreateItemRequest request, CancellationToken cancellationToken)
        {
            var response = new ResponseBase<GetItemResponse>();
            var validation = request.Validate();
            if (!validation.IsValid)
            {
                response.ValidationResult = validation;
                return response;
            }

            var item = new ItemEntity
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
            item = await _itemRepository.AddItemAsync(item, cancellationToken);
            await _itemRepository.CommitAsync(cancellationToken);

            response.Payload = GetItemResponse.FromItem(item);

            return response;
        }
    }
}
