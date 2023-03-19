using FluentValidation;
using ThinkBridge.ShopBridge.Domain.Requests.Item;

namespace ThinkBridge.ShopBridge.Domain.Validations.Item
{
    public class UpdateItemRequestValidation : AbstractValidator<UpdateItemRequest>
    {
        public UpdateItemRequestValidation()
        {
            RuleFor(i => i.Id)
                .NotNull();

            RuleFor(i => i.Name)
                .NotEmpty()
                .When(i => i.Name != null);

            RuleFor(i => i.Description)
                .NotEmpty()
                .When(i => i.Description != null);

            RuleFor(i => i.Price)
                .GreaterThanOrEqualTo(0);
        }
    }
}
