using DrinkApp.Domain.Drinks;
using DrinkApp.Domain.Drinks.Exceptions;
using DrinkApp.Domain.Machines.Exceptions;
using DrinkApp.Domain.Menus;

namespace DrinkApp.Domain.Machines
{
    public class CoffeeMachine: ICoffeeMachine
    {
        private const int MaximumCoffeeBeanCapacity = 25;
        private const int MaximumMilkCapacity = 20;

        public int CoffeeBeanRemaining { get; set; }

        public int MilkRemaining { get; set; }

        public ICoffeeMenu Menu { get; set; }

        public CoffeeMachine(int coffeeBeanCapacity = MaximumCoffeeBeanCapacity, int milkCapacity = MaximumMilkCapacity)
        {
            if (coffeeBeanCapacity > MaximumCoffeeBeanCapacity)
                throw new MaximumCapacityReachedException($"The maximum coffee bean capacity is {MaximumCoffeeBeanCapacity}, but {coffeeBeanCapacity} was specified.");

            if (milkCapacity > MaximumMilkCapacity)
                throw new MaximumCapacityReachedException($"The maximum milk capacity is {MaximumCoffeeBeanCapacity}, but {milkCapacity} was specified.");

            CoffeeBeanRemaining = coffeeBeanCapacity < 0 ? 0 : coffeeBeanCapacity;
            MilkRemaining = milkCapacity < 0 ? 0 : milkCapacity;

            Menu = new CoffeeMenu
            {
                Items = new()
                {
                    { 1, new BlackCoffee() },
                    { 2, new Cappuccino() },
                    { 3, new CafeLatte() }
                }
            };
        }
        
        public ICoffeeDrink PrepareMenuItem(short menuItemId, short teasSpoonsOfSugar, int? extraMilkInUnits = null)
        {
            var menuItem = Menu.GetMenuItem(menuItemId);

            if (menuItem == null)
                throw new InvalidMenuItemException($"Invalid menu item selected: {menuItemId}.");

            var preparedDrink = (ICoffeeDrink)menuItem.Clone();

            if (!HasEnoughCoffeeBeansForDrink(preparedDrink.CoffeeBeans))
                throw new InsufficientCoffeeBeansException($"There are not enough coffee beans to make a {preparedDrink.Name}.");

            CoffeeBeanRemaining -= preparedDrink.CoffeeBeans;

            if (!HasEnoughMilkForDrink(preparedDrink.MilkInUnits))
                throw new InsufficientMilkException($"There is not enough milk to make a {preparedDrink.Name}.");

            MilkRemaining -= preparedDrink.MilkInUnits;

            if (preparedDrink.IsAddingMilkOptional() && extraMilkInUnits.HasValue)
            {
                preparedDrink.AddMilk(extraMilkInUnits.Value);

                MilkRemaining -= extraMilkInUnits.Value;
            }

            if (teasSpoonsOfSugar > 0)
                preparedDrink.AddSugar(teasSpoonsOfSugar);

            return preparedDrink;
        }

        private bool HasEnoughCoffeeBeansForDrink(int totalBeansRequiredForDrink)
        {
            return CoffeeBeanRemaining >= totalBeansRequiredForDrink;
        }

        private bool HasEnoughMilkForDrink(int totalMilkRequiredForDrink)
        {
            return MilkRemaining >= totalMilkRequiredForDrink;
        }
    }
}