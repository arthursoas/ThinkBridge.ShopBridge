using NSubstitute;
using Shouldly;
using ThinkBridge.ShopBridge.Data.Repositiories;
using ThinkBridge.ShopBridge.Domain.Requests.Item;
using ThinkBridge.ShopBridge.WebAPI.Application.Handlers.Requests.Item;
using ItemEntity = ThinkBridge.ShopBridge.Domain.Entities.Item;

namespace ThinkBridge.ShopBridge.WebAPI.Tests.Application.Handlers.Requests.Item
{
    public class GetItemsHandlerTests
    {
        private readonly IItemRepository _itemRepository;
        private readonly GetItemsHandler _getItemsHandler;

        public GetItemsHandlerTests()
        {
            _itemRepository = Substitute.For<IItemRepository>();

            _getItemsHandler = new GetItemsHandler(
                _itemRepository);
        }

        [Fact]
        public async Task Handle_WhenThereIsNoItems_ShouldReturnEmptyListAsync()
        {
            // Arrange
            _itemRepository
                .SelectItemsAsync(CancellationToken.None)
                .Returns(new List<ItemEntity>());
            var request = new GetItemsRequest();

            // Act
            var response = await _getItemsHandler.Handle(request, CancellationToken.None);

            // Assert
            response.ValidationResult.IsValid.ShouldBeTrue();
            response.Payload.ShouldBeEmpty();
        }

        [Fact]
        public async Task Handle_WhenThereAreItems_ShouldReturnThemAsync()
        {
            // Arrange
            _itemRepository
                .SelectItemsAsync(CancellationToken.None)
                .Returns(new List<ItemEntity>
                {
                    new ItemEntity
                    {
                        Id = 1,
                        Name = "Name",
                        Description = "Description",
                        Price = 10,
                        CreateDate = DateTimeOffset.UtcNow,
                        UpdateDate = DateTimeOffset.UtcNow
                    }
                });
            var request = new GetItemsRequest();

            // Act
            var response = await _getItemsHandler.Handle(request, CancellationToken.None);

            // Assert
            response.ValidationResult.IsValid.ShouldBeTrue();
            response.Payload.ShouldNotBeEmpty();
            response.Payload.Count().ShouldBe(1);
        }
    }
}
