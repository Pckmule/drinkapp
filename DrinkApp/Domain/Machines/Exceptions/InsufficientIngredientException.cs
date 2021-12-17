using System;
using System.Diagnostics.CodeAnalysis;

namespace DrinkApp.Domain.Machines.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InsufficientIngredientException : ApplicationException
    {
        public InsufficientIngredientException() { }
        
        public InsufficientIngredientException(string message): base(message) { }
    }
}