using DrinkApp.Domain.Drinks;
using DrinkApp.Domain.Drinks.Exceptions;
using DrinkApp.Domain.Machines;
using DrinkApp.Domain.Machines.Exceptions;
using Xunit;

namespace DrinkApp.Tests.Unit.Domain.Machines
{
    public class CoffeeMachineTests
    {
        [Fact]
        public void PrepareMenuItem_MustThrowInsufficientCoffeeBeansException_WhenCoffeeBeanCapacityIsLessThanTheAmountRequiredToMakeTheDrink()
        {
            // Arrange
            const short menuItemId = 2;
            const short teaSpoonOfSugarToAdd = 0;

            var coffeeMachine = new CoffeeMachine
            {
                CoffeeBeanRemaining = 1,
                MilkRemaining = 20
            };

            // Act and Assert
            Assert.Throws<InsufficientCoffeeBeansException>(() => coffeeMachine.PrepareMenuItem(menuItemId, teaSpoonOfSugarToAdd));
        }

        [Fact]
        public void PrepareMenuItem_MustThrowInsufficientMilkException_WhenMilkCapacityIsLessThanTheAmountRequiredToMakeTheDrink()
        {
            // Arrange
            const short menuItemId = 2;
            const short teaSpoonOfSugarToAdd = 0;

            var coffeeMachine = new CoffeeMachine
            {
                CoffeeBeanRemaining = 20,
                MilkRemaining = 0
            };

            // Act and Assert
            Assert.Throws<InsufficientMilkException>(() => coffeeMachine.PrepareMenuItem(menuItemId, teaSpoonOfSugarToAdd));
        }

        [Fact]
        public void PrepareMenuItem_MustThrowInvalidMenuItemException_WhenMenuItemIsInvalid()
        {
            // Arrange
            const short expectedMenuItemId = 0;

            var coffeeMachine = new CoffeeMachine();

            // Act and Assert
            Assert.Throws<InvalidMenuItemException>(() => coffeeMachine.PrepareMenuItem(expectedMenuItemId, 0));
        }

        [Fact]
        public void PrepareMenuItem_MustReturnBlackCoffeeWithCorrectOptions_WhenMenuItemIsValidAndSugarIsSpecified()
        {
            // Arrange
            const short expectedMenuItemId = 1;
            var expectedMenuItem = new BlackCoffee
            {
                TeaSpoonsOfSugars = 2,
                MilkInUnits = 0
            };

            var coffeeMachine = new CoffeeMachine();

            // Act
            var menuItem = coffeeMachine.PrepareMenuItem(expectedMenuItemId, expectedMenuItem.TeaSpoonsOfSugars);

            // Assert
            Assert.NotNull(menuItem);
            Assert.IsType<BlackCoffee>(menuItem);
            Assert.Equal(expectedMenuItem.Name, menuItem.Name);
            Assert.Equal(expectedMenuItem.TeaSpoonsOfSugars, menuItem.TeaSpoonsOfSugars);
            Assert.Equal(expectedMenuItem.MilkInUnits, menuItem.MilkInUnits);
        }

        [Fact]
        public void PrepareMenuItem_MustReturnBlackCoffeeWithCorrectOptions_WhenMenuItemIsValidAndSugarAndMilkIsSpecified()
        {
            // Arrange
            const short expectedMenuItemId = 1;
            var expectedMenuItem = new BlackCoffee
            {
                TeaSpoonsOfSugars = 2,
                MilkInUnits = 2
            };

            var coffeeMachine = new CoffeeMachine();

            // Act
            var menuItem = coffeeMachine.PrepareMenuItem(expectedMenuItemId, expectedMenuItem.TeaSpoonsOfSugars, expectedMenuItem.MilkInUnits);

            // Assert
            Assert.NotNull(menuItem);
            Assert.IsType<BlackCoffee>(menuItem);
            Assert.Equal(expectedMenuItem.Name, menuItem.Name);
            Assert.Equal(expectedMenuItem.TeaSpoonsOfSugars, menuItem.TeaSpoonsOfSugars);
            Assert.Equal(expectedMenuItem.MilkInUnits, menuItem.MilkInUnits);
        }

        [Fact]
        public void Constructor_MustThrowMaximumCapacityReachedException_WhenCoffeeBeanCapacityIsHigherThanMaximumCoffeeBeanCapacity()
        {
            // Act and Assert
            Assert.Throws<MaximumCapacityReachedException>(() => new CoffeeMachine(30));
        }

        [Fact]
        public void Constructor_MustThrowMaximumCapacityReachedException_WhenMilkCapacityIsHigherThanMaximumMilkCapacity()
        {
            // Act and Assert
            Assert.Throws<MaximumCapacityReachedException>(() => new CoffeeMachine(20, 25));
        }
    }
}
