using System.Text;

namespace DrinkApp.Domain.Drinks
{
    public abstract class CoffeeDrink: Drink, ICoffeeDrink
    {
        public int CoffeeBeans { get; set; }

        public short TeaSpoonsOfSugars { get; set; }

        public int MilkInUnits { get; set; }

        public bool MilkOptional { get; set; }

        protected CoffeeDrink(short? spoonsOfSugars = null, int? milkInUnits = null)
        {
            CoffeeBeans = 0;

            if (spoonsOfSugars != null) 
                TeaSpoonsOfSugars = spoonsOfSugars.Value;

            if (milkInUnits != null) 
                MilkInUnits = milkInUnits.Value;
        }

        public virtual void AddSugar(short amountInTeaSpoons)
        {
            TeaSpoonsOfSugars += amountInTeaSpoons;
        }

        public virtual void AddMilk(int amountInUnits)
        {
            MilkInUnits += amountInUnits < 0 ? 0 : amountInUnits;
        }

        public virtual bool IsAddingMilkOptional()
        {
            return MilkOptional;
        }

        public override string GetPreparationOptionsAsText()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Milk - {MilkInUnits} units");
            sb.AppendLine($"Sugar - {TeaSpoonsOfSugars} spoons");

            return sb.ToString();
        }

        public new virtual object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());

            sb.AppendLine($"Coffee Beans - {CoffeeBeans}");
            sb.AppendLine($"Milk is Optional - {(MilkOptional ? "Yes" : "No")}");
            sb.AppendLine($"Milk - {MilkInUnits} units");
            sb.AppendLine($"TeaSpoonsOfSugars - {TeaSpoonsOfSugars}");

            return sb.ToString();
        }
    }
}
