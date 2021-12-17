using System.Diagnostics.CodeAnalysis;

namespace DrinkApp.Domain.Machines.Exceptions
{
    [ExcludeFromCodeCoverage]

    public class InsufficientCoffeeBeansException : InsufficientIngredientException
    {
        public InsufficientCoffeeBeansException() { }

        public InsufficientCoffeeBeansException(string message) : base(message) { }
    }
}