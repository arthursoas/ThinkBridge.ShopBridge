using FluentValidation.Results;

namespace ThinkBridge.ShopBridge.WebAPI.Application.Handlers
{
    public abstract class HandlerBase
    {
        public static ValidationFailure BuildError(string message)
        {
            return new ValidationFailure(string.Empty, message);
        }
    }
}
