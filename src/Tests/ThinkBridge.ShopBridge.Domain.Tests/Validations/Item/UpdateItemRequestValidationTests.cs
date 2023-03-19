using Shouldly;
using ThinkBridge.ShopBridge.Domain.Requests.Item;

namespace ThinkBridge.ShopBridge.Domain.Tests.Validations.Item
{
    public class UpdateItemRequestValidationTests
    {
        [Fact]
        public void Validate_WhenRequestIsValid_ShouldReturnNoErrors()
        {
            // Arrange
            var request = new UpdateItemRequest
            {
                Name = "Name",
                Description = "Description",
                Price = 10
            };

            // Act
            var result = request.Validate();

            // Assert
            result.IsValid.ShouldBeTrue();
            result.Errors.ShouldBeEmpty();
        }

        [Fact]
        public void Validate_WhenNameIsInvalid_ShouldReturnErrors()
        {
            // Arrange
            var request = new CreateItemRequest
            {
                Name = "",
                Description = "Description",
                Price = 10
            };

            // Act
            var result = request.Validate();

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
        }

        [Fact]
        public void Validate_WhenDescriptionIsInvalid_ShouldReturnErrors()
        {
            // Arrange
            var request = new CreateItemRequest
            {
                Name = "Name",
                Description = "",
                Price = 10
            };

            // Act
            var result = request.Validate();

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
        }

        [Fact]
        public void Validate_WhenPriceIsInvalid_ShouldReturnErrors()
        {
            // Arrange
            var request = new CreateItemRequest
            {
                Name = "Name",
                Description = "Description",
                Price = -5
            };

            // Act
            var result = request.Validate();

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
        }
    }
}
