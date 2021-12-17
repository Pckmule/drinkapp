using DrinkApp.Domain.Drinks;
using System.Text;
using Xunit;

namespace DrinkApp.Tests.Unit.Domain.Drinks
{
    public class CoffeeDrinkTests
    {
        [Fact]
        public void AddSugar_MustIncrementTeaSpoonsOfSugarsPropertyByAmountSpecified_WhenCalled()
        {
            // Arrange
            const short teaSpoonsOfSugarToAdd = 2;
            const short expectedTeaSpoonsOfSugar = 2;

            var testDrink = new TestDrink();

            // Act
            testDrink.AddSugar(teaSpoonsOfSugarToAdd);

            // Assert
            Assert.Equal(expectedTeaSpoonsOfSugar, testDrink.TeaSpoonsOfSugars);
        }

        [Fact]
        public void AddMilk_MustIncrementMilkInUnitsPropertyByAmountSpecified_WhenCalled()
        {
            // Arrange
            const short unitsOfMilkToAdd = 2;
            const short expectedUnitsOfMilk = 3;

            var testDrink = new TestDrink();

            // Act
            testDrink.AddMilk(unitsOfMilkToAdd);

            // Assert
            Assert.Equal(expectedUnitsOfMilk, testDrink.MilkInUnits);
        }

        [Fact]
        public void IsAddingMilkOptional_MustReturnTrue_WhenMilkIsOptionalPropertyIsTrue()
        {
            // Arrange
            const bool expectedMilkIsOptional = true;

            var testDrink = new TestDrink
            {
                MilkOptional = expectedMilkIsOptional
            };

            // Act
            var isOptional = testDrink.IsAddingMilkOptional();

            // Assert
            Assert.Equal(expectedMilkIsOptional, isOptional);
        }

        [Fact]
        public void IsAddingMilkOptional_MustReturnTrue_WhenMilkIsOptionalPropertyIsFalse()
        {
            // Arrange
            const bool expectedMilkIsOptional = false;

            var testDrink = new TestDrink
            {
                MilkOptional = expectedMilkIsOptional
            };

            // Act
            var isOptional = testDrink.IsAddingMilkOptional();

            // Assert
            Assert.Equal(expectedMilkIsOptional, isOptional);
        }

        [Fact]
        public void GetPreparationOptionsAsText_MustValidText_WhenCalled()
        {
            // Arrange
            const short expectedTeaSpoonsOfSugar = 0;
            const short expectedUnitsOfMilk = 1;

            var sb = new StringBuilder();

            sb.AppendLine($"Milk - {expectedUnitsOfMilk} units");
            sb.AppendLine($"Sugar - {expectedTeaSpoonsOfSugar} spoons");

            var expectedText = sb.ToString();

            var testDrink = new TestDrink();

            // Act
            var preparationText = testDrink.GetPreparationOptionsAsText();

            // Assert
            Assert.Equal(expectedText, preparationText);
        }

        [Fact]
        public void ToString_MustCorrectString_WhenCalledWithMilkOptionalSetToTrue()
        {
            // Arrange
            var sb = new StringBuilder();

            sb.AppendLine("Test:");
            sb.AppendLine("Coffee Beans - 1");
            sb.AppendLine("Milk is Optional - Yes");
            sb.AppendLine("Milk - 1 units");
            sb.AppendLine("TeaSpoonsOfSugars - 0");

            var expectedString = sb.ToString();

            var testDrink = new TestDrink
            {
                MilkOptional = true
            };

            // Act
            var actualString = testDrink.ToString();

            // Assert
            Assert.Equal(expectedString, actualString);
        }

        [Fact]
        public void ToString_MustCorrectString_WhenCalledWithMilkOptionalSetToFalse()
        {
            // Arrange
            var sb = new StringBuilder();

            sb.AppendLine("Test:");
            sb.AppendLine("Coffee Beans - 1");
            sb.AppendLine("Milk is Optional - No");
            sb.AppendLine("Milk - 1 units");
            sb.AppendLine("TeaSpoonsOfSugars - 0");

            var expectedString = sb.ToString();

            var testDrink = new TestDrink
            {
                MilkOptional = false
            };

            // Act
            var actualString = testDrink.ToString();

            // Assert
            Assert.Equal(expectedString, actualString);
        }

        [Fact]
        public void Constructor_MustInitialize_WhenCalledWithAllOptions()
        {
            // Arrange and Act
            _ = new TestDrink(1, 1);
        }

        [Fact]
        public void Constructor_MustInitialize_WhenCalledWithSpoonsOfSugarsOptionOnly()
        {
            // Arrange and Act
            _ = new TestDrink(1);
        }

        [Fact]
        public void Constructor_MustInitialize_WhenCalledWithMilkInUnitsOptionOnly()
        {
            // Arrange and Act
            _ = new TestDrink(milkInUnits: 1);
        }

        private class TestDrink : CoffeeDrink
        {
            public TestDrink(short? spoonsOfSugars = null, int? milkInUnits = null) : base(spoonsOfSugars, milkInUnits)
            {
                Name = "Test";
                CoffeeBeans = 1;
                MilkInUnits = 1;
            }
        }
    }
}
