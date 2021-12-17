using System.Diagnostics.CodeAnalysis;

namespace DrinkApp.Domain.Machines.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InsufficientMilkException : InsufficientIngredientException
    {
        public InsufficientMilkException() { }
        
        public InsufficientMilkException(string message): base(message) { }
    }
}