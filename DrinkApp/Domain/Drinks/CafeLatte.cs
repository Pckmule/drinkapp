namespace DrinkApp.Domain.Drinks
{
    public class CafeLatte : CoffeeDrink
    {
        public CafeLatte()
        {
            Name = "Café Latte";
            CoffeeBeans = 3;
            MilkInUnits = 2;
        }

        public override CafeLatte Clone()
        {
            return (CafeLatte)base.Clone();
        }
    }
}
