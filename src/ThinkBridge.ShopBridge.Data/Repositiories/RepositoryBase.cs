using Microsoft.EntityFrameworkCore;
using ThinkBridge.ShopBridge.Domain.Entities;

namespace ThinkBridge.ShopBridge.Data.Repositiories
{
    public abstract class RepositoryBase<TEntity>
            where TEntity : EntityBase
    {
        protected readonly DbSet<TEntity> DbSet;
        private readonly ShopBridgeDbContext _dbContext;

        public RepositoryBase(ShopBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.CommitAsync(cancellationToken);
        }
    }
}
