namespace ThinkBridge.ShopBridge.Domain.Entities
{
    public class Item : EntityBase
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
    }
}
