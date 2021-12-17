namespace DrinkApp.Domain.Drinks
{
    public interface ICoffeeDrink: IDrink
    {
        int CoffeeBeans { get; }

        short TeaSpoonsOfSugars { get; set; }

        int MilkInUnits { get; set; }

        bool MilkOptional { get; set; }

        public void AddSugar(short amountInTeaSpoons);

        public void AddMilk(int amountInUnits);
        
        public bool IsAddingMilkOptional();
    }
}