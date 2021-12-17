using System.Collections.Generic;
using DrinkApp.Domain.Drinks;

namespace DrinkApp.Domain.Menus
{
    public interface ICoffeeMenu
    {
        public Dictionary<short, ICoffeeDrink> Items { get; set; }

        public ICoffeeDrink GetMenuItem(short id);

        public bool IsValidMenuItemId(short id);

        public string GetMenuAsText();
    }
}