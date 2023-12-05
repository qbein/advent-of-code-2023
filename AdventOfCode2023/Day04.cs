namespace AdventOfCode2023;

public class Day04
{
    public static int SolvePart01(IEnumerable<string> lines)
    {
        return lines.Aggregate(0, (acc, line) =>
        {
            var game = ParseGame(line);
            var matches = game.Winning.Intersect(game.Your).Count();
            return acc + (int)Math.Pow(2, matches-1) * 1;
        });
    }

    private static (IEnumerable<int> Winning, IEnumerable<int> Your) ParseGame(string line)
    {
        var parts = line.Split(":")[1].Split('|');

        return (
            parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse),
            parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
        );
    }
}