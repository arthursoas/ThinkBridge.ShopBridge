using Shouldly;
using ThinkBridge.ShopBridge.Domain.Requests.Item;

namespace ThinkBridge.ShopBridge.Domain.Tests.Validations.Item
{
    public class GetItemRequestValidationTests
    {
        [Fact]
        public void Validate_WhenRequestIsValid_ShouldReturnNoErrors()
        {
            // Arrange
            var request = new GetItemRequest
            {
                Id = 10
            };

            // Act
            var result = request.Validate();

            // Assert
            result.IsValid.ShouldBeTrue();
            result.Errors.ShouldBeEmpty();
        }
    }
}
