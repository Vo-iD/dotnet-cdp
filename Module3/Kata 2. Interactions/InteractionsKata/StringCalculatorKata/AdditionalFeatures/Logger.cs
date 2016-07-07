using System;

namespace StringCalculatorKata.AdditionalFeatures
{
    public class Logger : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine("{0}. Timestamp (UTC): {1}. Log message: {2}.",
                Guid.NewGuid(), DateTime.UtcNow, message);
        }
    }
}
