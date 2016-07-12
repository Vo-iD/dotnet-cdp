using scalc.Components;
using StringCalculatorKata;
using StringCalculatorKata.Contracts;

namespace scalc
{
    public class Program
    {
        public static ILogger Logger { get; set; }
        public static IWebService WebService { get; set; }
        public static IConsoleProxy Console { get; set; }

        static Program()
        {
            Logger = new Logger();
            Console = new ConsoleProxy();
            WebService = new WebService();
        }

        public static void Main(string[] args)
        {
            var calculator = new Calculator(Logger, WebService, Console);

            if (args.Length > 0)
            {
                calculator.Add(args[0]);
            }

            Console.WriteLine("another input please");

            string input;
            while (!string.IsNullOrEmpty(input = Console.Read()))
            {
                calculator.Add(input);
            }
        }
    }
}
