namespace DrinkApp.Domain.Drinks
{
    public class BlackCoffee: CoffeeDrink
    {
        public BlackCoffee(bool addMilk = false)
        {
            Name = "Americano";
            CoffeeBeans = 2;
            MilkInUnits = addMilk ? 1 : 0;
            MilkOptional = true;
        }
        
        public override BlackCoffee Clone()
        {
            return (BlackCoffee)base.Clone();
        }
    }
}
