using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day01
{
    public static int SolvePart01(IEnumerable<string> lines)
    {
        return lines
            .Aggregate(0, (prev, curr) =>
            {
                var str = Regex.Replace(curr, "[^0-9]", "");
                
                return prev + int.Parse($"{str[0]}{str[^1]}");
            });
    }
    
    public static int SolvePart02(IEnumerable<string> lines)
    {
        return SolvePart01(
            lines.Select(l => l.CollapseNumbers())
        );
    }
}