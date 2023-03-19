using FluentValidation.Results;
using ThinkBridge.ShopBridge.Domain.Validations.Item;

namespace ThinkBridge.ShopBridge.Domain.Requests.Item
{
    public class CreateItemRequest : CreateUpdateItemRequest
    {
        /// <summary>
        /// Validates the request
        /// </summary>
        /// <returns>Validation result</returns>
        public override ValidationResult Validate()
        {
            return new CreateItemRequestValidation().Validate(this);
        }
    }
}
