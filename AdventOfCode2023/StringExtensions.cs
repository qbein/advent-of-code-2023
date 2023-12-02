using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public static class StringExtensions
{
    private static readonly string[] Digits = {
        "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
    };

    private static readonly Regex NumbersPattern = new(
        "([0-9]|one|two|three|four|five|six|seven|eight|nine)"
    );

    public static string? CollapseNumbers(this string input)
    {
        var output = "";

        for (var i = 0; i < input.Length; i++)
        {
            var match = NumbersPattern.Match(input, i);

            if (!match.Success)
                return output;

            var digitIndex = Array.IndexOf(Digits, match.Value);
            output += digitIndex > -1
                ? (digitIndex + 1).ToString()
                : match.Value;

            i = match.Index;
        }

        return output;
    }
}