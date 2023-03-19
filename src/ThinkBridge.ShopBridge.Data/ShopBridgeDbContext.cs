using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ThinkBridge.ShopBridge.Domain.Entities;

namespace ThinkBridge.ShopBridge.Data
{
    public class ShopBridgeDbContext : DbContext
    {
        public ShopBridgeDbContext(DbContextOptions<ShopBridgeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            var entityEntries = ChangeTracker
                .Entries()
                .Where(entry => entry.Entity is EntityBase);

            foreach (var entry in entityEntries)
            {
                var entity = (EntityBase)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreateDate = DateTimeOffset.UtcNow;
                    entity.UpdateDate = entity.CreateDate;
                }
                if (entry.State == EntityState.Modified)
                {
                    entity.UpdateDate = DateTimeOffset.UtcNow;
                }
            }

            return await SaveChangesAsync(cancellationToken) > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopBridgeDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
