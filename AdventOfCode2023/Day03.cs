using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day03
{
    private static Regex PartNumberRegex = new("[0-9]+");
    
    public static long SolvePart01(string[] schematic)
    {
        long count = 0;
        
        for(var lineIndex=0; lineIndex<schematic.Length; lineIndex++)
        {
            var line = schematic[lineIndex];
            foreach (Match partNumberMatch in PartNumberRegex.Matches(line))
            {
                if (HasAdjacentSymbol(
                        schematic,
                        lineIndex,
                        partNumberMatch.Index,
                        partNumberMatch.Index + partNumberMatch.Length
                    ))
                    count += int.Parse(partNumberMatch.Value);
            }
        }

        return count;
    }

    private static bool HasAdjacentSymbol(
        string[] schematic,
        int lineIndex,
        int columnStartIndex,
        int columnEndIndex
    )
    {
        if (lineIndex > 0)
        {
            if (HasSymbolInRange(
                    schematic[lineIndex - 1],
                    Math.Max(0, columnStartIndex - 1),
                    Math.Min(schematic[lineIndex].Length, columnEndIndex + 1)
                ))
                return true;
        }

        if (columnStartIndex > 0 && HasSymbolAtPosition(
                schematic[lineIndex],
                columnStartIndex - 1
            ))
            return true;

        if (columnEndIndex < schematic[lineIndex].Length-1 && HasSymbolAtPosition(
                schematic[lineIndex],
                columnEndIndex
            ))
            return true;

        if (lineIndex < schematic.Length-1)
        {
            if (HasSymbolInRange(
                    schematic[lineIndex + 1],
                    Math.Max(0, columnStartIndex - 1),
                    Math.Min(schematic[lineIndex].Length, columnEndIndex + 1)
                ))
                return true;
        }

        return false;
    }

    private static bool HasSymbolInRange(
        string line,
        int columnStartIndex,
        int columnEndIndex
    )
    {
        for (var i = columnStartIndex; i < columnEndIndex; i++)
            if (HasSymbolAtPosition(line, i))
                return true;

        return false;
    }

    private static bool HasSymbolAtPosition(string line, int index)
    {
        return line[index] != '.';
    }
}