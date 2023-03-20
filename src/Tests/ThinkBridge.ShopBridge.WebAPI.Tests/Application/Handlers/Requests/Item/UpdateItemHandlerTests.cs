using NSubstitute;
using Shouldly;
using ThinkBridge.ShopBridge.Data.Repositiories;
using ThinkBridge.ShopBridge.Domain.Requests.Item;
using ThinkBridge.ShopBridge.WebAPI.Application.Handlers.Requests.Item;
using ItemEntity = ThinkBridge.ShopBridge.Domain.Entities.Item;

namespace ThinkBridge.ShopBridge.WebAPI.Tests.Application.Handlers.Requests.Item
{
    public class UpdateItemHandlerTests
    {
        const int ITEM_ID = 10;

        private readonly IItemRepository _itemRepository;
        private readonly UpdateItemHandler _updateItemHandler;

        public UpdateItemHandlerTests()
        {
            _itemRepository = Substitute.For<IItemRepository>();
            MockItemRepository();

            _updateItemHandler = new UpdateItemHandler(
                _itemRepository);
        }

        [Fact]
        public async Task Handle_WhenRequestIsNotValid_ShouldReturnErrorAsync()
        {
            // Arrange
            var request = new UpdateItemRequest
            {
                Name = ""
            };

            // Act
            var response = await _updateItemHandler.Handle(request, CancellationToken.None);

            // Assert
            response.ValidationResult.IsValid.ShouldBeFalse();
            response.ValidationResult.Errors.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task Handle_WhenItemDoesNotExist_ShouldReturnErrorAsync()
        {
            // Arrange
            var request = new UpdateItemRequest
            {
                Id = ITEM_ID * 2,
                Name = "New Name"
            };

            // Act
            var response = await _updateItemHandler.Handle(request, CancellationToken.None);

            // Assert
            response.ValidationResult.IsValid.ShouldBeFalse();
            response.ValidationResult.Errors.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task Handle_WhenRequestIsValid_ShouldAddItemAndReturnItAsync()
        {
            // Arrange
            var request = new UpdateItemRequest
            {
                Id = ITEM_ID,
                Name = "New name"
            };

            // Act
            var response = await _updateItemHandler.Handle(request, CancellationToken.None);

            // Assert
            response.ValidationResult.IsValid.ShouldBeTrue();
            response.Payload.Name.ShouldBe(request.Name);

            _itemRepository
                .Received(1)
                .UpdateItem(
                    Arg.Is<ItemEntity>(i => i.Name == request.Name));
        }

        private void MockItemRepository()
        {
            _itemRepository
                .UpdateItem(
                    Arg.Any<ItemEntity>())
                .Returns(new ItemEntity
                {
                    Id = 1,
                    Name = "New name",
                    Description = "Description",
                    Price = 10,
                    CreateDate = DateTimeOffset.UtcNow.AddHours(-1),
                    UpdateDate = DateTimeOffset.UtcNow
                });

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
