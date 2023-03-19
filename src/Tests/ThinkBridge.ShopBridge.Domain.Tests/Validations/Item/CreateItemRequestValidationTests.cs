using Shouldly;
using ThinkBridge.ShopBridge.Domain.Requests.Item;

namespace ThinkBridge.ShopBridge.Domain.Tests.Validations.Item
{
    public class CreateItemRequestValidationTests
    {
        [Fact]
        public void Validate_WhenRequestIsValid_ShouldReturnNoErrors()
        {
            // Arrange
            var request = new CreateItemRequest
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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Validate_WhenNameIsInvalid_ShouldReturnErrors(string name)
        {
            // Arrange
            var request = new CreateItemRequest
            {
                Name = name,
                Description = "Description",
                Price = 10
            };

            // Act
            var result = request.Validate();

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Validate_WhenDescriptionIsInvalid_ShouldReturnErrors(string description)
        {
            // Arrange
            var request = new CreateItemRequest
            {
                Name = "Name",
                Description = description,
                Price = 10
            };

            // Act
            var result = request.Validate();

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_WhenPriceIsInvalid_ShouldReturnErrors(decimal price)
        {
            // Arrange
            var request = new CreateItemRequest
            {
                Name = "Name",
                Description = "Description",
                Price = price
            };

            // Act
            var result = request.Validate();

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
        }
    }
}
