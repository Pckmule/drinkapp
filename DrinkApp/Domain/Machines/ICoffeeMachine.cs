using DrinkApp.Domain.Drinks;
using DrinkApp.Domain.Menus;

namespace DrinkApp.Domain.Machines
{
    public interface ICoffeeMachine
    {
        public ICoffeeMenu Menu { get; set; }

        public int CoffeeBeanRemaining { get; set; }

        public int MilkRemaining { get; set; }

        public ICoffeeDrink PrepareMenuItem(short menuItemId, short teasSpoonsOfSugar, int? extraMilkInUnits = null);
    }
}