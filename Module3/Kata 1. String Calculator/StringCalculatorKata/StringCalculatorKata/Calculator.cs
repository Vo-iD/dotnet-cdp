using System.Linq;

namespace StringCalculatorKata
{
    class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var result = numbers.Split(',').Sum(x => int.Parse(x));

            return result;
        }
    }
}
