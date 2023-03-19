using FluentValidation.Results;
using ThinkBridge.ShopBridge.Domain.Responses;

namespace ThinkBridge.ShopBridge.Domain.Requests.Item
{
    public class GetItemsRequest : RequestBase<ResponseBase<GetItemResponse[]>>
    {
        public override ValidationResult Validate()
        {
            return new ValidationResult();
        }
    }
}
