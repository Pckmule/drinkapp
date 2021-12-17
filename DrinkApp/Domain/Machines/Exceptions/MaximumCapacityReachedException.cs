using System;
using System.Diagnostics.CodeAnalysis;

namespace DrinkApp.Domain.Machines.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class MaximumCapacityReachedException : ApplicationException
    {
        public MaximumCapacityReachedException() { }

        public MaximumCapacityReachedException(string message): base(message) { }
    }
}