using DrinkApp.Domain.Drinks;
using Xunit;

namespace DrinkApp.Tests.Unit.Domain.Drinks
{
    public class CappuccinoTests
    {
        [Fact]
        public void Clone_MustReturnANewInstanceOfCappuccino_WhenCalled()
        {
            // Arrange
            var existingCappuccino = new Cappuccino();

            // Act
            var cappuccino = existingCappuccino.Clone();

            // Assert
            Assert.NotNull(cappuccino);
            Assert.IsType<Cappuccino>(cappuccino);
            Assert.NotEqual(existingCappuccino, cappuccino);
        }
    }
}
