using NSubstitute;
using Shouldly;
using ThinkBridge.ShopBridge.Data.Repositiories;
using ThinkBridge.ShopBridge.Domain.Requests.Item;
using ThinkBridge.ShopBridge.WebAPI.Application.Handlers.Requests.Item;
using ItemEntity = ThinkBridge.ShopBridge.Domain.Entities.Item;

namespace ThinkBridge.ShopBridge.WebAPI.Tests.Application.Handlers.Requests.Item
{
    public class CreateItemHandlerTests
    {
        private readonly IItemRepository _itemRepository;
        private readonly CreateItemHandler _createItemHandler;

        public CreateItemHandlerTests()
        {
            _itemRepository = Substitute.For<IItemRepository>();
            MockItemRepository();

            _createItemHandler = new CreateItemHandler(
                _itemRepository);
        }

        [Fact]
        public async Task Handle_WhenRequestIsNotValid_ShouldReturnErrorAsync()
        {
            // Arrange
            var request = new CreateItemRequest();

            // Act
            var response = await _createItemHandler.Handle(request, CancellationToken.None);

            // Assert
            response.ValidationResult.IsValid.ShouldBeFalse();
            response.ValidationResult.Errors.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task Handle_WhenRequestIsValid_ShouldAddItemAndReturnItAsync()
        {
            // Arrange
            var request = new CreateItemRequest
            {
                Name = "Name",
                Description = "Description",
                Price = 10
            };

            // Act
            var response = await _createItemHandler.Handle(request, CancellationToken.None);

            // Assert
            response.ValidationResult.IsValid.ShouldBeTrue();
            response.Payload.Name.ShouldBe(request.Name);
            response.Payload.Description.ShouldBe(request.Description);
            response.Payload.Price.ShouldBe(request.Price);

            await _itemRepository
                .Received(1)
                .AddItemAsync(
                    Arg.Is<ItemEntity>(i =>
                        i.Name == request.Name &&
                        i.Description == request.Description &&
                        i.Price == request.Price),
                    CancellationToken.None);
        }

        private void MockItemRepository()
        {
            _itemRepository
                .AddItemAsync(
                    Arg.Any<ItemEntity>(),
                    CancellationToken.None)
                .Returns(new ItemEntity
                {
                    Id = 1,
                    Name = "Name",
                    Description = "Description",
                    Price = 10,
                    CreateDate = DateTimeOffset.UtcNow,
                    UpdateDate = DateTimeOffset.UtcNow
                });
        }
    }
}
