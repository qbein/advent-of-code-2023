using System.Collections;

namespace AdventOfCode2023;

public class Day05
{
    public static long SolvePart01(string[] lines)
    {
        var seedMap = SeedMap.FromLines(lines);

        return seedMap.Seeds.Select(s => seedMap.LookupSeedLocation(s)).Min();
    }

    private record Range(long Source, long Destination, long Length);

    private class SeedMap
    {
        public SeedMap(IEnumerable<long> seeds)
        {
            this.Seeds = seeds;
        }

        private readonly IDictionary<int, IList<Range>> _maps = new Dictionary<int, IList<Range>>();

        public IEnumerable<long> Seeds { get; init; }

        public long LookupSeedLocation(long sourceValue)
        {
            foreach (var map in _maps)
            {
                foreach (var range in map.Value)
                {
                    if (range.Source <= sourceValue && range.Source + range.Length > sourceValue)
                    {
                        sourceValue = range.Destination + sourceValue - range.Source;
                        break;
                    }
                }
            }

            return sourceValue;
        }

        public static SeedMap FromLines(IReadOnlyList<string> lines)
        {
            var mapIndex = -1;

            var seedMap = new SeedMap(
                lines[0].Split(
                    ' ',
                    StringSplitOptions.RemoveEmptyEntries
                ).Skip(1).Select(long.Parse)
            );
            
            for (var i = 0; i < 7; i++)
                seedMap._maps[i] = new List<Range>();

            for (int i = 2; i < lines.Count; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.EndsWith("map:"))
                {
                    mapIndex++;
                    continue;
                }

                var spec = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                seedMap._maps[mapIndex].Add(new Range(spec[1], spec[0], spec[2]));
            }

            return seedMap;
        }
    }
}