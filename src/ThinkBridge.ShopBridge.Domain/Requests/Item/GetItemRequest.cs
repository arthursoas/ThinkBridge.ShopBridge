using FluentValidation.Results;
using ThinkBridge.ShopBridge.Domain.Responses;
using ThinkBridge.ShopBridge.Domain.Validations.Item;

namespace ThinkBridge.ShopBridge.Domain.Requests.Item
{
    public class GetItemRequest : RequestBase<ResponseBase<GetItemResponse>>
    {
        /// <summary>
        /// Item id
        /// </summary>
        public int Id { get; set; }

        public override ValidationResult Validate()
        {
            return new GetItemRequestValidation().Validate(this);
        }
    }
}
