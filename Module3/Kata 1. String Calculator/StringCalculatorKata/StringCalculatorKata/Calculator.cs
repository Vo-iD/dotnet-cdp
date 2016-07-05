using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    class Calculator
    {
        private static readonly string[] DefaultDelimiters = {",", "\n"};
        private static string DelimiterPattern = "//.\n.+";
        private static string FewDelimitersPattern = "//.+\n";

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = GetDelimiters(numbers);
            var numbersAsString = GetClearNumbersString(numbers);
            var result = GetSum(numbersAsString, delimiters);

            return result;
        }

        private string[] GetDelimiters(string input)
        {
            var delimiters = GetSimpleDelimiter(input);

            if (!delimiters.Any())
            {
                delimiters = GetFewDelimiters(input);
            }

            return delimiters.Any() ? delimiters : DefaultDelimiters;
        }


        private string GetClearNumbersString(string input)
        {
            if (Regex.IsMatch(input, DelimiterPattern, RegexOptions.IgnoreCase)
                || Regex.IsMatch(input, FewDelimitersPattern, RegexOptions.IgnoreCase))
            {
                return input.Substring(input.IndexOf("\n", StringComparison.Ordinal));
            }

            return input;
        }

        private string[] GetSimpleDelimiter(string input)
        {
            var delimters = new string[] {};
            var match = Regex.Match(input, DelimiterPattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var delimiter = match.Value.Substring(2, 1);
                delimters = new[] {delimiter};
            }

            return delimters;
        }

        private string[] GetFewDelimiters(string input)
        {
            var delimters = new string[] { };
            var match = Regex.Match(input, FewDelimitersPattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                var notReadyDelimiters = match.Value.Substring(2, match.Value.Length - 2).Split(']');
                delimters = notReadyDelimiters.Select(delimiter => delimiter.Substring(1)).ToArray();
            }

            return delimters;
        }

        private int GetSum(string input, string[] delimiters)
        {
            var stringNumbers = input.Split(delimiters, StringSplitOptions.None);
            var numbers = stringNumbers.Select(int.Parse);
            if (numbers.Any(n => n < 0))
            {
                throw new ArgumentException(string.Format("Negatives not allowed. Numbers: {0}",
                    string.Join(";", numbers.Where(n => n < 0))));
            }

            return numbers.Where(n => n <= 1000).Sum();
        }
    }
}
