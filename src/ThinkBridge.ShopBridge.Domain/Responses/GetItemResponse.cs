namespace ThinkBridge.ShopBridge.Domain.Responses
{
    public class GetItemResponse
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
    }
}
