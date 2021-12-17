using DrinkApp.Domain.Drinks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrinkApp.Domain.Menus
{
    public class CoffeeMenu: ICoffeeMenu
    {
        public Dictionary<short, ICoffeeDrink> Items { get; set; } = new()
        {
            { 1, new BlackCoffee() },
            { 2, new Cappuccino() },
            { 3, new CafeLatte() }
        };

        public ICoffeeDrink GetMenuItem(short id)
        {
            return Items.TryGetValue(id, out var drinkToMake) ? drinkToMake : null;
        }

        public bool IsValidMenuItemId(short id)
        {
            return Items.TryGetValue(id, out _);
        }

        public string GetMenuAsText()
        {
            if (Items == null || !Items.Any()) 
                return "There are no menu items.";

            var sb = new StringBuilder();

            foreach (var (id, drink) in Items)
            {
                sb.AppendLine($"{id}. {drink.Name}");
            }

            return sb.ToString();
        }
    }
}