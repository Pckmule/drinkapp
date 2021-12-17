using System.Text;

namespace DrinkApp.Domain.Drinks
{
    public class Drink: IDrink
    {
        public string Name { get; set; }

        public virtual string GetPreparationOptionsAsText()
        {
            return string.Empty;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public new virtual string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Name + ":");

            return sb.ToString();
        }
    }
}