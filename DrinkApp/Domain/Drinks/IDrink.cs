using System;

namespace DrinkApp.Domain.Drinks
{
    public interface IDrink: ICloneable
    {
        string Name { get; set; }

        string GetPreparationOptionsAsText();
    }
}