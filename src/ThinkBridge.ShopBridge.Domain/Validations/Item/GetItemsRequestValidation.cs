using FluentValidation;
using ThinkBridge.ShopBridge.Domain.Requests.Item;

namespace ThinkBridge.ShopBridge.Domain.Validations.Item
{
    public class GetItemsRequestValidation : AbstractValidator<GetItemsRequest>
    {
        public GetItemsRequestValidation()
        {
            RuleFor(u => u.Take)
                .GreaterThanOrEqualTo(0);

            RuleFor(u => u.Skip)
                .GreaterThanOrEqualTo(0);
        }
    }
}
