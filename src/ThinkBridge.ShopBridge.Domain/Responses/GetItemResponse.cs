using ThinkBridge.ShopBridge.Domain.Entities;

namespace ThinkBridge.ShopBridge.Domain.Responses
{
    public class GetItemResponse
    {
        /// <summary>
        /// Item id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Item price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Time item was created
        /// </summary>
        public DateTimeOffset CreateDate { get;  set; }

        /// <summary>
        /// Last iime item was updated
        /// </summary>
        public DateTimeOffset UpdateDate { get;  set; }

        public static GetItemResponse FromItem(Item item)
        {
            return new GetItemResponse
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CreateDate = item.CreateDate,
                UpdateDate = item.UpdateDate
            };
        }
    }
}
