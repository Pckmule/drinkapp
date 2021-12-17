using DrinkApp.Domain.Drinks;
using Xunit;

namespace DrinkApp.Tests.Unit.Domain.Drinks
{
    public class CafeLatteTests
    {
        [Fact]
        public void Clone_MustReturnANewInstanceOfCafeLatte_WhenCalled()
        {
            // Arrange
            var existingCafeLatte = new CafeLatte();

            // Act
            var cafeLatte = existingCafeLatte.Clone();

            // Assert
            Assert.NotNull(cafeLatte);
            Assert.IsType<CafeLatte>(cafeLatte);
            Assert.NotEqual(existingCafeLatte, cafeLatte);
        }
    }
}
