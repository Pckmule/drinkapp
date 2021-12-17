using System;

namespace DrinkApp.Domain.Common
{
    public interface IConsole
    {
        public void WriteLine(string message);

        public string ReadLine();

        void SetForegroundColor(ConsoleColor consoleColor);
        
        void ResetColor();
    }
}
