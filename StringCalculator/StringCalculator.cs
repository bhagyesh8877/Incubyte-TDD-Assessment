using System;
using System.Collections.Generic;
using System.Linq;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        var delimiters = new List<string> { ",", "\n" };

        if (numbers.StartsWith("//"))
        {
            var delimiterEndIndex = numbers.IndexOf('\n');
            var customDelimiter = numbers.Substring(2, delimiterEndIndex - 2);

            if (customDelimiter.StartsWith("[") && customDelimiter.EndsWith("]"))
            {
                customDelimiter = customDelimiter.Substring(1, customDelimiter.Length - 2);
            }

            delimiters.Add(customDelimiter);
            numbers = numbers.Substring(delimiterEndIndex + 1);
        }

        var numberList = SplitNumbers(numbers, delimiters.ToArray());
        var negativeNumbers = numberList.Where(n => n < 0).ToList();

        if (negativeNumbers.Any())
            throw new ArgumentException($"negative numbers not allowed: {string.Join(", ", negativeNumbers)}");

        return numberList.Sum();
    }

    private List<int> SplitNumbers(string numbers, string[] delimiters)
    {
        return numbers
            .Split(delimiters, StringSplitOptions.None)
            .Select(int.Parse)
            .ToList();
    }
}
