using ThinkBridge.ShopBridge.Domain.Entities;

namespace ThinkBridge.ShopBridge.Data.Repositiories
{
    public interface IItemRepository : IRepository
    {
        /// <summary>
        /// Add a new item to the database
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Added item</returns>
        Task<Item> AddItemAsync(Item item, CancellationToken cancellationToken);

        /// <summary>
        /// Get an item by id from database
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Item or null</returns>
        Task<Item?> GetItemAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Update an item on the database
        /// </summary>
        /// <param name="item">Item to b updated</param>
        /// <returns>Updated item</returns>
        Item UpdateItem(Item item);

        /// <summary>
        /// Select all items from database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Items</returns>
        Task<ICollection<Item>> SelectItemsAsync(CancellationToken cancellationToken);
    }
}
