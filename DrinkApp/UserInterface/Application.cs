using DrinkApp.Domain.Common;
using DrinkApp.Domain.Drinks;
using DrinkApp.Domain.Drinks.Exceptions;
using DrinkApp.Domain.Machines;
using DrinkApp.Domain.Machines.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DrinkApp.UserInterface
{
    public class Application
    {
        public const string OffCommand = "off";
        public const string HelpCommand = "help";
        public const string MenuCommand = "menu";

        public const string YesInput = "y";

        private readonly IConsole _console;

        private readonly Dictionary<string, string> _commands = new()
        {
            { OffCommand, "Exits the application." },
            { HelpCommand, "Displays help information." },
            { MenuCommand, "Displays the drinks menu." }
        };

        private readonly ICoffeeMachine _coffeeMachine;

        public Application(IConsole console = null, ICoffeeMachine coffeeMachine = null)
        {
            _console = console ?? new ConsoleWrapper();
            _coffeeMachine = coffeeMachine ?? new CoffeeMachine();
        }
        
        // Excluded because there is no significant functionality to test.
        [ExcludeFromCodeCoverage]
        public void Start()
        {
            DisplayWelcomeMessage();
            DisplayMenu();
            TakeInstruction();
        }

        // Excluded because unit testing an infinite while loop is rather tricky and all significant code already has tests.
        [ExcludeFromCodeCoverage]
        public void TakeInstruction()
        {
            while (true)
            {
                var command = _console.ReadLine();

                if (!IsValidInstruction(command))
                {
                    _console.WriteLine("That instruction is not recognized. Type 'help' for help information.");
                    continue;
                }

                switch (command?.ToLower())
                {
                    case OffCommand:
                        _console.WriteLine("Thank you for your business!");
                        return;

                    case HelpCommand:
                        DisplayHelp();
                        continue;

                    case MenuCommand:
                        DisplayMenu();
                        continue;
                }

                if (!short.TryParse(command, out var drinkId) || !_coffeeMachine.Menu.IsValidMenuItemId(drinkId))
                {
                    DisplayMenuItemDoesNotExistMessage();
                    continue;
                }

                ProcessDrinkOrder(drinkId);

                _console.WriteLine("Would you like something else? (Y/n)");

                var wantsSomethingElse = _console.ReadLine();

                if (wantsSomethingElse?.ToLower() == YesInput)
                    _console.WriteLine("OK. What would you like?");
                else 
                {
                    _console.WriteLine("Have a great day! Next customer please!");
                    DisplayWelcomeMessage();
                    DisplayMenu();
                }
            }
        }

        public void ProcessDrinkOrder(short drinkId)
        {
            try
            {
                var drinkInfo = _coffeeMachine.Menu.GetMenuItem(drinkId);

                if (drinkInfo == null)
                    throw new InvalidMenuItemException($"Invalid menu item selected: {drinkId}.");

                _console.WriteLine("How many sugars would you like?");

                if (!short.TryParse(_console.ReadLine(), out var teaSpoonsOfSugarToAdd))
                    teaSpoonsOfSugarToAdd = 0;

                var extraMilkUnitsToAdd = 0;
                if (drinkInfo.IsAddingMilkOptional())
                {
                    _console.WriteLine("Would you like milk? (Y/n)");
                    if (_console.ReadLine()?.ToLower() == YesInput)
                    {
                        extraMilkUnitsToAdd = 1;
                    }
                }

                DisplayPreparedDrinkInformation(_coffeeMachine.PrepareMenuItem(drinkId, teaSpoonsOfSugarToAdd, extraMilkUnitsToAdd));
            }
            catch (InvalidMenuItemException)
            {
                DisplayMenuItemDoesNotExistMessage();
            }
            catch (InsufficientCoffeeBeansException)
            {
                _console.SetForegroundColor(ConsoleColor.Yellow);
                _console.WriteLine("We're sorry! The coffee machine doesn't have enough coffee beans left to prepare your drink.");
                _console.ResetColor();
            }
            catch (InsufficientMilkException)
            {
                _console.SetForegroundColor(ConsoleColor.Yellow);
                _console.WriteLine("We're sorry! The coffee machine doesn't have enough milk left to prepare your drink.");
                _console.ResetColor();
            }

            if (_coffeeMachine.CoffeeBeanRemaining < 6)
                DisplayLowBeanWarningMessage(_coffeeMachine.CoffeeBeanRemaining);
        }

        public bool IsValidInstruction(string instruction)
        {
            if (string.IsNullOrWhiteSpace(instruction))
                return false;

            if (_commands.ContainsKey(instruction.ToLower()))
                return true;

            return short.TryParse(instruction, out _);
        }
        
        public void DisplayPreparedDrinkInformation(ICoffeeDrink preparedDrink)
        {
            _console.SetForegroundColor(ConsoleColor.Green);
            _console.WriteLine($"Your {preparedDrink.Name} is ready!");
            _console.WriteLine(preparedDrink.GetPreparationOptionsAsText());
            _console.ResetColor();
        }

        public void DisplayMenu()
        {
            _console.SetForegroundColor(ConsoleColor.Cyan);
            _console.WriteLine(Environment.NewLine + _coffeeMachine.Menu.GetMenuAsText() + Environment.NewLine);
            _console.ResetColor();
        }

        public void DisplayHelp()
        {
            _console.WriteLine("Help Information" + Environment.NewLine);

            _console.WriteLine("Commands:");
            foreach (var (name, description) in _commands)
            {
                _console.WriteLine($"   {name.PadRight(20, '.')} {description}");
            }
        }

        public void DisplayMenuItemDoesNotExistMessage()
        {
            _console.WriteLine("That item doesn't exist on the menu?");
        }

        public void DisplayLowBeanWarningMessage(int beansLeft)
        {
            _console.SetForegroundColor(ConsoleColor.Red);
            _console.WriteLine($"WARNING: There {(beansLeft < 2 ? "is" : "are")} only {beansLeft} bean(s) left in the machine!");
            _console.ResetColor();
        }

        public void DisplayWelcomeMessage()
        {
            _console.WriteLine("Welcome to 'Coffee Express'. May I take your order?");
        }
    }
}