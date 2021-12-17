namespace DrinkApp.Domain.Drinks
{
    public class Cappuccino: CoffeeDrink
    {
        public Cappuccino()
        {
            Name = "Cappuccino";
            CoffeeBeans = 5;
            MilkInUnits = 3;
        }

        public override Cappuccino Clone()
        {
            return (Cappuccino)base.Clone();
        }
    }
}
