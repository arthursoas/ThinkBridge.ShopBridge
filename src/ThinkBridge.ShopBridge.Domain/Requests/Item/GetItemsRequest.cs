using FluentValidation.Results;
using ThinkBridge.ShopBridge.Domain.Responses;
using ThinkBridge.ShopBridge.Domain.Validations.Item;

namespace ThinkBridge.ShopBridge.Domain.Requests.Item
{
    public class GetItemsRequest : RequestBase<ResponseBase<GetItemResponse[]>>
    {
        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int Take { get; set; } = 10;

        /// <summary>
        /// Items to skip on page
        /// </summary>
        public int Skip { get; set; }

        public override ValidationResult Validate()
        {
            return new GetItemsRequestValidation().Validate(this);
        }
    }
}
