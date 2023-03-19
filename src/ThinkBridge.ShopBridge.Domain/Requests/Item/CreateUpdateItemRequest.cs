using FluentValidation.Results;
using ThinkBridge.ShopBridge.Domain.Responses;

namespace ThinkBridge.ShopBridge.Domain.Requests.Item
{
    public abstract class CreateUpdateItemRequest : RequestBase<ResponseBase<GetItemResponse>>
    {
        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Item price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Validates the request
        /// </summary>
        /// <returns>Validation result</returns>
        public override abstract ValidationResult Validate();
    }
}
