using FluentValidation.Results;
using MediatR;

namespace ThinkBridge.ShopBridge.Domain.Requests
{
    public abstract class RequestBase<T> : IRequest<T>
    {
        public abstract ValidationResult Validate();
    }
}
