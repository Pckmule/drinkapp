using DrinkApp.Domain.Common;
using DrinkApp.Domain.Machines;
using NSubstitute;
using System;

namespace DrinkApp.Tests
{
    public static class MockHelper
    {
        public static IConsole GetConsoleMock()
        {
            var mock = Substitute.For<IConsole>();

            mock.ReadLine().Returns("");
            mock.WriteLine(Arg.Any<string>());
            mock.ResetColor();
            mock.SetForegroundColor(Arg.Any<ConsoleColor>());

            return mock;
        }

        public static ICoffeeMachine GetCoffeeMachineMock(int? coffeeBeanRemaining = null, int ? milkRemaining = null)
        {
            var mock = Substitute.For<ICoffeeMachine>();

            if(coffeeBeanRemaining.HasValue)
                mock.CoffeeBeanRemaining = coffeeBeanRemaining.Value;

            if (milkRemaining.HasValue)
                mock.MilkRemaining = milkRemaining.Value;

            return mock;
        }
    }
}