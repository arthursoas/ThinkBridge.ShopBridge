using FluentValidation.Results;
using ThinkBridge.ShopBridge.Domain.Responses;
using ItemEntity = ThinkBridge.ShopBridge.Domain.Entities.Item;

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

        /// <summary>
        /// Convert a <see cref="CreateUpdateItemRequest"/> to an <see cref="ItemEntity"/>
        /// </summary>
        /// <param name="request">Create or update item request</param>
        /// <returns>Item</returns>
        public ItemEntity ToItem()
        {
            return new ItemEntity
            {
                Name = Name,
                Description = Description,
                Price = Price
            };
        }
    }
}
