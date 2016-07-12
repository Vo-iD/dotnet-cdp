using System;
using StringCalculatorKata.Contracts;

namespace scalc.Components
{
    public class Logger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine("Logger says: {0}", message);
        }
    }
}
