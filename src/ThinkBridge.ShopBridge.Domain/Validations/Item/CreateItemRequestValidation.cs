using FluentValidation;
using ThinkBridge.ShopBridge.Domain.Requests.Item;

namespace ThinkBridge.ShopBridge.Domain.Validations.Item
{
    public class CreateItemRequestValidation : AbstractValidator<CreateItemRequest>
    {
        public CreateItemRequestValidation()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(i => i.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(i => i.Price)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
