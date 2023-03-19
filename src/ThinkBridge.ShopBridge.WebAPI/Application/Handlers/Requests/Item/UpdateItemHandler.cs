using MediatR;
using ThinkBridge.ShopBridge.Data.Repositiories;
using ThinkBridge.ShopBridge.Domain.Entities;
using ThinkBridge.ShopBridge.Domain.Requests.Item;
using ThinkBridge.ShopBridge.Domain.Responses;

namespace ThinkBridge.ShopBridge.WebAPI.Application.Handlers.Requests.Item
{
    public class UpdateItemHandler : HandlerBase, IRequestHandler<UpdateItemRequest, ResponseBase<GetItemResponse>>
    {
        private readonly IItemRepository _itemRepository;

        public UpdateItemHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ResponseBase<GetItemResponse>> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
        {
            var response = new ResponseBase<GetItemResponse>();
            var validation = request.Validate();
            if (!validation.IsValid)
            {
                response.ValidationResult = validation;
                return response;
            }

            var item = await _itemRepository.GetItemAsync(request.Id, cancellationToken);
            if (item == default)
            {
                response.ValidationResult.Errors.Add(BuildError($"There is no item with id equals to '{request.Id}'."));
                return response;
            }

            item.MergeEntity(request.ToItem());

            item = _itemRepository.UpdateItem(item);
            await _itemRepository.CommitAsync(cancellationToken);

            response.Payload = GetItemResponse.FromItem(item);

            return response;
        }
    }
}
