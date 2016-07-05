using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    class Calculator
    {
        private static readonly char[] DefaultDelimiters = {',', '\n'};
        private static string DelimiterPattern = "//.\n.+";

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = GetDelimiters(numbers);
            var numbersAsString = GetClearNumbersString(numbers);
            var result = numbersAsString.Split(delimiters).Sum(x => int.Parse(x));

            return result;
        }

        private char[] GetDelimiters(string input)
        {
            var match = Regex.Match(input, DelimiterPattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var delimiter = match.Value.Substring(2, 1).ToCharArray();
                return delimiter;
            }

            return DefaultDelimiters;
        }

        private string GetClearNumbersString(string input)
        {
            if(Regex.IsMatch(input, DelimiterPattern, RegexOptions.IgnoreCase))
            {
                return input.Substring(input.IndexOf("\n", StringComparison.Ordinal));
            }

            return input;
        }
    }
}
