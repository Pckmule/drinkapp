using DrinkApp.Domain.Drinks;
using DrinkApp.Domain.Drinks.Exceptions;
using DrinkApp.Domain.Machines.Exceptions;
using DrinkApp.UserInterface;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace DrinkApp.Tests.Unit.UserInterface
{
    public class ApplicationTests
    {
        [Fact]
        public void ProcessDrinkOrder_MustNotThrowException_WhenMenuItemExistsForDrinkId()
        {
            // Arrange
            const short drinkId = 3;
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act and Assert
            application.ProcessDrinkOrder(drinkId);
        }

        [Fact]
        public void ProcessDrinkOrder_MustWriteMessageToConsole_WhenMenuItemDoesNotExistForDrinkId()
        {
            // Arrange
            const short drinkId = 30;

            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var coffeeMachineMock = MockHelper.GetCoffeeMachineMock();
                coffeeMachineMock.PrepareMenuItem(Arg.Is(drinkId), Arg.Any<short>(), Arg.Any<int?>()).Throws<InvalidMenuItemException>();

            var application = new Application(consoleWrapperMock);

            application.ProcessDrinkOrder(drinkId);

            // Act and Assert
            consoleWrapperMock.Received().WriteLine("That item doesn't exist on the menu?");
        }

        [Fact]
        public void ProcessDrinkOrder_MustWriteMessageToConsole_WhenInsufficientCoffeeBeansExceptionIsThrown()
        {
            // Arrange
            const short drinkId = 1;
            const short remainingBeans = 0;

            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var coffeeMachineMock = MockHelper.GetCoffeeMachineMock(remainingBeans);
            coffeeMachineMock.PrepareMenuItem(Arg.Is(drinkId), Arg.Any<short>(), Arg.Any<int?>()).Throws<InsufficientCoffeeBeansException>();

            var application = new Application(consoleWrapperMock, coffeeMachineMock);
            
            // Act
            application.ProcessDrinkOrder(drinkId);

            // Assert
            consoleWrapperMock.Received().WriteLine("We're sorry! The coffee machine doesn't have enough coffee beans left to prepare your drink.");
        }

        [Fact]
        public void ProcessDrinkOrder_MustWriteMessageToConsole_WhenInsufficientMilkExceptionIsThrown()
        {
            // Arrange
            const short drinkId = 1;
            const short remainingBeans = 0;

            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var coffeeMachineMock = MockHelper.GetCoffeeMachineMock(remainingBeans);
            coffeeMachineMock.PrepareMenuItem(Arg.Is(drinkId), Arg.Any<short>(), Arg.Any<int?>()).Throws<InsufficientMilkException>();

            var application = new Application(consoleWrapperMock, coffeeMachineMock);

            // Act
            application.ProcessDrinkOrder(drinkId);

            // Assert
            consoleWrapperMock.Received().WriteLine("We're sorry! The coffee machine doesn't have enough milk left to prepare your drink.");
        }


        [Fact]
        public void ProcessDrinkOrder_MustNotThrowException_WhenAddOptionalMilkIsYes()
        {
            // Arrange
            const short drinkId = 1;

            var consoleWrapperMock = MockHelper.GetConsoleMock();
            consoleWrapperMock.ReadLine().Returns("y");

            var application = new Application(consoleWrapperMock);

            // Act and Assert
            application.ProcessDrinkOrder(drinkId);
        }

        [Fact]
        public void ProcessDrinkOrder_MustNotThrowException_WhenAddOptionalMilkIsNo()
        {
            // Arrange
            const short drinkId = 1;

            var consoleWrapperMock = MockHelper.GetConsoleMock();
            consoleWrapperMock.ReadLine().Returns("n");

            var application = new Application(consoleWrapperMock);

            // Act and Assert
            application.ProcessDrinkOrder(drinkId);
        }

        [Fact]
        public void IsValidInstruction_MustReturnTrue_WhenInstructionIsStandardMenuInstruction()
        {
            // Arrange
            const string instruction = Application.MenuCommand;
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act
            var isValid = application.IsValidInstruction(instruction);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidInstruction_MustReturnTrue_WhenInstructionIsStandardHelpInstruction()
        {
            // Arrange
            const string instruction = Application.HelpCommand;
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act
            var isValid = application.IsValidInstruction(instruction);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidInstruction_MustReturnTrue_WhenInstructionIsStandardOffInstruction()
        {
            // Arrange
            const string instruction = Application.OffCommand;
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act
            var isValid = application.IsValidInstruction(instruction);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidInstruction_MustReturnTrue_WhenInstructionIsValidMenuItemId()
        {
            // Arrange
            const string instruction = "1";
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act
            var isValid = application.IsValidInstruction(instruction);

            // Assert

            Assert.True(isValid);
        }

        [Fact]
        public void IsValidInstruction_MustReturnFalse_WhenInstructionIsNull()
        {
            // Arrange
            const string instruction = null;
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act
            var isValid = application.IsValidInstruction(instruction);

            // Assert

            Assert.False(isValid);
        }

        [Fact]
        public void IsValidInstruction_MustReturnFalse_WhenInstructionIsEmptyString()
        {
            // Arrange
            const string instruction = "";
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act
            var isValid = application.IsValidInstruction(instruction);

            // Assert

            Assert.False(isValid);
        }

        [Fact]
        public void IsValidInstruction_MustReturnFalse_WhenInstructionIsNotStandardOrValidMenuItemId()
        {
            // Arrange
            const string instruction = "invalid instruction";
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act
            var isValid = application.IsValidInstruction(instruction);

            // Assert

            Assert.False(isValid);
        }

        [Fact]
        public void DisplayPreparedDrinkInformation_MustNotRaiseExceptions_WhenCalled()
        {
            // Arrange
            var preparedDrink = (ICoffeeDrink)new Cappuccino();
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act and Assert
            application.DisplayPreparedDrinkInformation(preparedDrink);
        }

        [Fact]
        public void DisplayHelp_MustNotRaiseExceptions_WhenCalled()
        {
            // Arrange
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act and Assert
            application.DisplayHelp();
        }

        [Fact]
        public void DisplayMenu_MustNotRaiseExceptions_WhenCalled()
        {
            // Arrange
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act and Assert
            application.DisplayMenu();
        }

        [Fact]
        public void DisplayMenuItemDoesNotExistMessage_MustNotRaiseExceptions_WhenCalled()
        {
            // Arrange
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act and Assert
            application.DisplayMenuItemDoesNotExistMessage();
        }

        [Fact]
        public void DisplayLowBeanWarningMessage_MustNotRaiseExceptions_WhenCalled()
        {
            // Arrange
            const int beansLeft = 1;
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act and Assert
            application.DisplayLowBeanWarningMessage(beansLeft);
        }

        [Fact]
        public void DisplayWelcomeMessage_MustNotRaiseExceptions_WhenCalled()
        {
            // Arrange
            var consoleWrapperMock = MockHelper.GetConsoleMock();

            var application = new Application(consoleWrapperMock);

            // Act and Assert
            application.DisplayWelcomeMessage();
        }
    }
}
