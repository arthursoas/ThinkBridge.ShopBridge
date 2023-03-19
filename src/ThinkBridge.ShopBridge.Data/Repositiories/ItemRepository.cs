using ThinkBridge.ShopBridge.Domain.Entities;

namespace ThinkBridge.ShopBridge.Data.Repositiories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(ShopBridgeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Item> AddItemAsync(Item item, CancellationToken cancellationToken)
        {
            await DbSet.AddAsync(item, cancellationToken);

            return item;
        }
    }
}
