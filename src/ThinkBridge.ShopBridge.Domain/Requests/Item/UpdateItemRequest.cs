using FluentValidation.Results;
using ThinkBridge.ShopBridge.Domain.Validations.Item;

namespace ThinkBridge.ShopBridge.Domain.Requests.Item
{
    public class UpdateItemRequest : CreateUpdateItemRequest
    {
        /// <summary>
        /// Item id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Validates the request
        /// </summary>
        /// <returns>Validation result</returns>
        public override ValidationResult Validate()
        {
            return new UpdateItemRequestValidation().Validate(this);
        }
    }
}
