using FluentValidation;
using ThinkBridge.ShopBridge.Domain.Requests.Item;

namespace ThinkBridge.ShopBridge.Domain.Validations.Item
{
    public class UpdateItemRequestValidation : AbstractValidator<UpdateItemRequest>
    {
        public UpdateItemRequestValidation()
        {
            RuleFor(i => i.Name)
                .NotEmpty();

            RuleFor(i => i.Description)
                .NotEmpty();

            RuleFor(i => i.Price)
                .GreaterThan(0);
        }
    }
}
