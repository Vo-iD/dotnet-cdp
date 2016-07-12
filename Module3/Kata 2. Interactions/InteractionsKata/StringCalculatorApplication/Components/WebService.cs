using System;
using StringCalculatorKata.Contracts;

namespace scalc.Components
{
    public class WebService : IWebService
    {
        public void Notify(string message)
        {
            Console.WriteLine("Web service says: {0}", message);
        }
    }
}
