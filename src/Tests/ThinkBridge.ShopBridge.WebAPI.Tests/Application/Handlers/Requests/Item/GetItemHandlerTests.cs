using NSubstitute;
using Shouldly;
using ThinkBridge.ShopBridge.Data.Repositiories;
using ThinkBridge.ShopBridge.Domain.Requests.Item;
using ThinkBridge.ShopBridge.Domain.Responses;
using ThinkBridge.ShopBridge.WebAPI.Application.Handlers.Requests.Item;
using ItemEntity = ThinkBridge.ShopBridge.Domain.Entities.Item;

namespace ThinkBridge.ShopBridge.WebAPI.Tests.Application.Handlers.Requests.Item
{
    public class GetItemHandlerTests
    {
        const int ITEM_ID = 10;

        private readonly IItemRepository _itemRepository;
        private readonly GetItemHandler _getItemHandler;

        public GetItemHandlerTests()
        {
            _itemRepository = Substitute.For<IItemRepository>();
            MockItemRepository();

            _getItemHandler = new GetItemHandler(
                _itemRepository);
        }

        [Fact]
        public async Task Handle_WhenItemDoesNotExist_ShouldReturnErrorAsync()
        {
            // Arrange
            var request = new GetItemRequest
            {
                Id = ITEM_ID * 2
            };

            // Act
            var response = await _getItemHandler.Handle(request, CancellationToken.None);

            // Assert
            response.ValidationResult.IsValid.ShouldBeFalse();
            response.ValidationResult.Errors.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task Handle_WhenRequestIsValid_ShouldAddItemAndReturnItAsync()
        {
            // Arrange
            var request = new GetItemRequest
            {
                Id = ITEM_ID
            };

            // Act
            var response = await _getItemHandler.Handle(request, CancellationToken.None);

            // Assert
            response.ValidationResult.IsValid.ShouldBeTrue();
            response.Payload.ShouldNotBeNull();
            response.Payload.ShouldBeOfType<GetItemResponse>();
        }

        private void MockItemRepository()
        {
            _itemRepository
               .GetItemAsync(ITEM_ID, CancellationToken.None)
               .Returns(new ItemEntity
               {
                   Id = ITEM_ID,
                   Name = "Name",
                   Description = "Description",
                   Price = 10,
                   CreateDate = DateTimeOffset.UtcNow,
                   UpdateDate = DateTimeOffset.UtcNow
               });
        }
    }
}
