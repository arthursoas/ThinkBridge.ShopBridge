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
    }
}
