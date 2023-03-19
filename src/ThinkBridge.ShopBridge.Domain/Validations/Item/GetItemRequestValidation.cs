using FluentValidation;
using ThinkBridge.ShopBridge.Domain.Requests.Item;

namespace ThinkBridge.ShopBridge.Domain.Validations.Item
{
    public class GetItemRequestValidation : AbstractValidator<GetItemRequest>
    {
        public GetItemRequestValidation()
        {
            RuleFor(u => u.Id)
                .NotNull();
        }
    }
}
