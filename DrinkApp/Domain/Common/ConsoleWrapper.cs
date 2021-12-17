using System;
using System.Diagnostics.CodeAnalysis;

namespace DrinkApp.Domain.Common
{
    [ExcludeFromCodeCoverage]
    public class ConsoleWrapper : IConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void SetForegroundColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }

        public void ResetColor()
        {
            Console.ResetColor();
        }
    }
}
