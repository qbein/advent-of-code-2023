using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day01
{
    public static int Solve(string[] lines)
    {
        return lines
            .Aggregate(0, (prev, curr) =>
            {
                var str = Regex.Replace(curr, "[^0-9]", "");
                return prev + int.Parse($"{str[0]}{str[^1]}");
            });
    }
}