using Microsoft.EntityFrameworkCore;
using Shouldly;
using ThinkBridge.ShopBridge.Data.Repositiories;
using ThinkBridge.ShopBridge.Data.Tests.Fixture;
using ThinkBridge.ShopBridge.Domain.Entities;

namespace ThinkBridge.ShopBridge.Data.Tests.Repositories
{
    public class ItemRepositoryTests : IClassFixture<ShopBridgeBdContextFixture>
    {
        private readonly ShopBridgeBdContextFixture _shopBridgeBdContextFixture;
        private readonly ItemRepository _itemRepository;
        private readonly DateTimeOffset _utcNow = new(2020, 10, 10, 12, 0, 0, TimeSpan.FromHours(0));

        public ItemRepositoryTests(ShopBridgeBdContextFixture shopBridgeBdContextFixture)
        {
            _shopBridgeBdContextFixture = shopBridgeBdContextFixture;
            _itemRepository = new ItemRepository(_shopBridgeBdContextFixture.ShopBridgeDbContext);
            SeedDatabase();
        }

        [Fact]
        public async Task UpdateItemAsync_WhenItemIsValid_ShouldUpdateItemAndReturnItAsync()
        {
            // Arrange
            var item = (await _itemRepository.SelectItemsAsync(CancellationToken.None)).First();
            item.Name = "New name";

            // Act
            var updatedItem = _itemRepository.UpdateItem(item);
            _shopBridgeBdContextFixture.ShopBridgeDbContext.SaveChanges();

            // Assert
            updatedItem.Name.ShouldBe(item.Name);

            var storedItem = await _itemRepository.GetItemAsync(item.Id, CancellationToken.None);
            storedItem.ShouldBeEquivalentTo(item);
        }

        [Fact]
        public async Task AddItemAsync_WhenItemIsValid_ShouldAddItemAndReturnItAsync()
        {
            // Arrange
            var item = new Item
            {
                Name = "Custom item",
                Description = "Custom item",
                Price = 10
            };

            // Act
            var addedItem = await _itemRepository.AddItemAsync(item, CancellationToken.None);
            _shopBridgeBdContextFixture.ShopBridgeDbContext.SaveChanges();

            // Assert
            addedItem.Name.ShouldBe(item.Name);
            addedItem.Description.ShouldBe(item.Description);
            addedItem.Price.ShouldBe(item.Price);

            var storedItem = await _itemRepository.GetItemAsync(addedItem.Id, CancellationToken.None);
            storedItem.ShouldBeEquivalentTo(addedItem);
        }

        [Fact]
        public async Task SelectItemsAsync_WhenThereAreItemsOnDatabase_ShouldReturnItemsAsync()
        {
            // Act
            var items = await _itemRepository.SelectItemsAsync(CancellationToken.None);

            // Assert
            items.Count.ShouldBe(5);
        }

        private void SeedDatabase()
        {
            _shopBridgeBdContextFixture.ShopBridgeDbContext.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(e => e.State = EntityState.Detached);

            _shopBridgeBdContextFixture.ShopBridgeDbContext.Database.EnsureDeleted();
            _shopBridgeBdContextFixture.ShopBridgeDbContext.Database.EnsureCreated();

            for (var index = 0; index < 5; index++)
            {
                _shopBridgeBdContextFixture.ShopBridgeDbContext.Add(new Item
                {
                    Name = $"Item {index}",
                    Description = $"description of item {index}",
                    Price = 10
                });
            }

            _shopBridgeBdContextFixture.ShopBridgeDbContext.SaveChanges();
        }
    }
}
