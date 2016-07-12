using System;
using StringCalculatorKata.Contracts;

namespace scalc.Components
{
    public class ConsoleProxy : IConsoleProxy
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
