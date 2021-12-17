using System;
using System.Diagnostics.CodeAnalysis;

namespace DrinkApp.Domain.Drinks.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidMenuItemException: ApplicationException
    {
        public InvalidMenuItemException() { }
        
        public InvalidMenuItemException(string message): base(message) { }
    }
}