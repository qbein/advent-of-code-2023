using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day03
{
    private static readonly Regex PartNumberRegex = new("[0-9]+");

    private const char Gear = '*';
    
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

    public static long SolvePart02(string[] schematic)
    {
        long gearRatioSum = 0;

        for (var lineIndex = 0; lineIndex < schematic.Length; lineIndex++)
        {
            for (var colIndex = 0; colIndex < schematic[lineIndex].Length; colIndex++)
            {
                if (schematic[lineIndex][colIndex] != Gear) continue;

                var adjacentInts = GetAdjacentInts(schematic, lineIndex, colIndex);
                if (adjacentInts.Count == 2)
                    gearRatioSum += adjacentInts.Aggregate((current, next) => current * next);
            }
        }

        return gearRatioSum;
    }

    private static IList<int> GetAdjacentInts(
        string[] schematic,
        int lineIndex,
        int colIndex
    )
    {
        var ints = new List<int>();
        
        // Row above
        if (lineIndex > 0)
            ints.AddRange(GetLineInts(schematic[lineIndex-1], colIndex, false));
        
        // Adjacent
        ints.AddRange(GetLineInts(schematic[lineIndex], colIndex, true));
        
        // Row below
        if (lineIndex < schematic.Length)
            ints.AddRange(GetLineInts(schematic[lineIndex+1], colIndex, false));
        
        return ints;
    }

    private static IList<int> GetLineInts(string line, int colIndex, bool onlyAdjacent)
    {
        var ints = new List<int>();
        
        if (!onlyAdjacent && char.IsDigit(line[colIndex]))
            ints.Add(ExtractInt(line, colIndex));
        else
        {
            if (colIndex > 0 && char.IsDigit(line[colIndex - 1]))
                ints.Add(ExtractInt(line, colIndex - 1));
            if (colIndex < line.Length && char.IsDigit(line[colIndex + 1]))
                ints.Add(ExtractInt(line, colIndex + 1));
        }

        return ints;
    }

    private static int ExtractInt(string line, int colIndex)
    {
        if (!char.IsDigit(line[colIndex]))
            throw new InvalidOperationException($"Character ({line[colIndex]}) is not a digit");

        var startIndex = colIndex;
        while (startIndex > 0 && char.IsDigit(line[startIndex - 1]))
            startIndex--;

        var endIndex = colIndex;
        while (endIndex < line.Length && char.IsDigit(line[endIndex]))
            endIndex++;

        return int.Parse(line.Substring(startIndex, endIndex - startIndex));
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