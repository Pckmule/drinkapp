using DrinkApp.Domain.Drinks;
using DrinkApp.Domain.Menus;
using System;
using System.Collections.Generic;
using Xunit;

namespace DrinkApp.Tests.Unit.Domain.Menus
{
    public class CoffeeMenuTests
    {
        [Fact]
        public void GetMenuItem_MustReturnCorrectMenuItem_WhenCalledWithMenuItemId()
        {
            // Arrange
            const short expectedMenuItemId = 1;
            var expectedMenuItem = new BlackCoffee();

            var coffeeMenu = new CoffeeMenu();

            // Act
            var menuItem = coffeeMenu.GetMenuItem(expectedMenuItemId);

            // Assert
            Assert.NotNull(menuItem);
            Assert.IsType<BlackCoffee>(menuItem);
            Assert.Equal(expectedMenuItem.Name, menuItem.Name);
            Assert.Equal(expectedMenuItem.CoffeeBeans, menuItem.CoffeeBeans);
            Assert.Equal(expectedMenuItem.MilkInUnits, menuItem.MilkInUnits);
            Assert.Equal(expectedMenuItem.MilkOptional, menuItem.MilkOptional);
        }

        [Fact]
        public void IsValidMenuItemId_MustReturnTrue_WhenMenuItemIdIsValid()
        {
            // Arrange
            const short expectedMenuItemId = 1;

            var coffeeMenu = new CoffeeMenu();

            // Act
            var isValid = coffeeMenu.IsValidMenuItemId(expectedMenuItemId);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidMenuItemId_MustReturnTrue_WhenMenuItemIdIsInvalid()
        {
            // Arrange
            const short expectedMenuItemId = 10;

            var coffeeMenu = new CoffeeMenu();

            // Act
            var isValid = coffeeMenu.IsValidMenuItemId(expectedMenuItemId);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void GetMenuAsText_MustCorrectMenuText_WhenItemsAreNotEmpty()
        {
            // Arrange
            var expectedMenuText = $"1. Americano{Environment.NewLine}2. Cappuccino{Environment.NewLine}3. Café Latte{Environment.NewLine}";

            var coffeeMenu = new CoffeeMenu();

            // Act
            var menuText = coffeeMenu.GetMenuAsText();

            // Assert
            Assert.Equal(expectedMenuText, menuText);
        }

        [Fact]
        public void GetMenuAsText_MustCorrectMenuText_WhenItemsAreEmpty()
        {
            // Arrange
            const string expectedMenuText = "There are no menu items.";

            var coffeeMenu = new CoffeeMenu
            {
                Items = new Dictionary<short, ICoffeeDrink>()
            };

            // Act
            var menuText = coffeeMenu.GetMenuAsText();

            // Assert
            Assert.Equal(expectedMenuText, menuText);
        }

        [Fact]
        public void GetMenuAsText_MustCorrectMenuText_WhenItemsIsNull()
        {
            // Arrange
            const string expectedMenuText = "There are no menu items.";

            var coffeeMenu = new CoffeeMenu
            {
                Items = null
            };

            // Act
            var menuText = coffeeMenu.GetMenuAsText();

            // Assert
            Assert.Equal(expectedMenuText, menuText);
        }
    }
}
