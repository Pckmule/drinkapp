using DrinkApp.UserInterface;
using System.Diagnostics.CodeAnalysis;

namespace DrinkApp
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static readonly Application Application = new();

        static void Main(string[] args)
        {
            Application.Start();
        }
    }
}
