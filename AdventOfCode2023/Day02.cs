namespace AdventOfCode2023;

public class Day02
{
    public static int SolvePart01(
        IEnumerable<string> lines, 
        Dictionary<string, int> maxMarbleCount
        )
    {
        return lines.Aggregate(0, (acc, curr) =>
        {
            var gameParts = curr.Split(':');
            var gameIndex = int.Parse(gameParts[0][gameParts[0].LastIndexOf(' ')..].Trim());

            if (gameParts[1].Split(';').All(set =>
                    set.Split(',').All(marbleCount =>
                    {
                        var marbleParts = marbleCount.Trim().Split(' ');
                        var count = int.Parse(marbleParts[0]);
                        var color = marbleParts[1].Trim();

                        maxMarbleCount.TryGetValue(color, out var maxCount);
                        return count <= maxCount;
                    })
                ))
                return acc + gameIndex;

            return acc;
        });
    }
}