using System.Text;
using DrinkApp.Domain.Drinks;
using Xunit;

namespace DrinkApp.Tests.Unit.Domain.Drinks
{
    public class DrinkTests
    {
        [Fact]
        public void Clone_MustReturnANewInstanceOfDrink_WhenCalled()
        {
            // Arrange
            var existingDrink = new Drink();

            // Act
            var drink = existingDrink.Clone();

            // Assert
            Assert.NotNull(drink);
            Assert.IsType<Drink>(drink);
            Assert.NotEqual(existingDrink, drink);
        }

        [Fact]
        public void ToString_MustReturnCorrectString_WhenCalled()
        {
            // Arrange
            var drink = new Drink
            {
                Name = "Test"
            };

            var sb = new StringBuilder();
            sb.AppendLine("Test:");

            var expectedString = sb.ToString();

            // Act
            var actualString = drink.ToString();

            // Assert
            Assert.Equal(expectedString, actualString);
        }

        [Fact]
        public void GetPreparationOptionsAsText_MustEmptyString_WhenCalled()
        {
            // Arrange
            var expectedText = string.Empty;

            var testDrink = new Drink();

            // Act
            var preparationText = testDrink.GetPreparationOptionsAsText();

            // Assert
            Assert.Equal(expectedText, preparationText);
        }

    }
}
