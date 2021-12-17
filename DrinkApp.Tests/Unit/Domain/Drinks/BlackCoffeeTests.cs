using DrinkApp.Domain.Drinks;
using Xunit;

namespace DrinkApp.Tests.Unit.Domain.Drinks
{
    public class BlackCoffeeTests
    {
        [Fact]
        public void Clone_MustReturnANewInstanceOfBlackCoffee_WhenCalled()
        {
            // Arrange
            var existingBlackCoffee = new BlackCoffee();

            // Act
            var blackCoffee = existingBlackCoffee.Clone();

            // Assert
            Assert.NotNull(blackCoffee);
            Assert.IsType<BlackCoffee>(blackCoffee);
            Assert.NotEqual(existingBlackCoffee, blackCoffee);
        }
    }
}
