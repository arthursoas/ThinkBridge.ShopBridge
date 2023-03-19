using FluentValidation.Results;

namespace ThinkBridge.ShopBridge.Domain.Responses
{
    public class ResponseBase<T>
    {
        public T? Payload { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public ResponseBase()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
