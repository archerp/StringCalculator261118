using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            if (input.StartsWith("//"))
                input = ReformatInputWithCommaDelimiter(input);

            input = ConvertNewLinesToComma(input);
            
            var numbers = GetNumbers(input);

            IgnoreNumbersGreaterThan1000(numbers);

            RejectNegativeNumbers(numbers);

            return numbers.Sum();
        }

        private static void IgnoreNumbersGreaterThan1000(List<int> numbers)
        {
            numbers.RemoveAll(x => x > 1000);
        }

        private static void RejectNegativeNumbers(List<int> numbers)
        {
            var negativeNumbers = numbers.FindAll(x => x < 0);
            if (negativeNumbers.Any())
                throw new Exception(string.Format("negative number was input : {0}", string.Join(",", negativeNumbers.ToArray())));
        }

        private static string ReformatInputWithCommaDelimiter(string input)
        {
            var delimitedNumbers = RemoveDelimiterDefinition(input); 

            foreach (var delimiter in GetDelimiters(input))
            {
                delimitedNumbers = delimitedNumbers.Replace(delimiter, ",");
            }

            return delimitedNumbers;
        }

        private static string RemoveDelimiterDefinition(string input)
        {
            return input.Substring(input.IndexOf("\n") + 1);
        }

        private static string[] GetDelimiters(string input)
        {
            return input.Split("\n")[0].TrimStart('/', '[').TrimEnd(']').Split("][").ToArray();
        }

        private static string ConvertNewLinesToComma(string rawInput)
        {
            var input = rawInput.Replace("\n", ",");
            return input;
        }

        private static List<int> GetNumbers(string input)
        {
            var numbers = input.Split(',').ToList().ConvertAll(int.Parse);
            return numbers;
        }
    }
}
