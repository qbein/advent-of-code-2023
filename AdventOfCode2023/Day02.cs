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
            var game = ParseGame(curr);

            if (game.Sets.All(set =>
                    set.All(marbleCount =>
                    {
                        maxMarbleCount.TryGetValue(marbleCount.Color, out var maxCount);
                        return marbleCount.Count <= maxCount;
                    })
                ))
                return acc + game.Index;

            return acc;
        });
    }

    public static int SolvePart02(IEnumerable<string> lines)
    {
        return lines.Aggregate(0, (acc, curr) =>
        {
            var game = ParseGame(curr);

            var minimum = new Dictionary<string, int>();

            foreach (var set in game.Sets)
            {
                foreach (var marble in set)
                {
                    if (minimum.TryAdd(marble.Color, marble.Count)) continue;
                    if (marble.Count > minimum[marble.Color])
                        minimum[marble.Color] = marble.Count;
                }
            }
            
            return acc + minimum.Values.Aggregate((power, minimumCount) => power * minimumCount);
        });
    }

    private static Game ParseGame(string line)
    {
        var gameParts = line.Split(':');
        var gameIndex = int.Parse(gameParts[0][gameParts[0].LastIndexOf(' ')..].Trim());

        var sets = gameParts[1].Split(';').Select(set =>
            set.Split(',').Select(
                marbleCount =>
                {
                    var marbleParts = marbleCount.Trim().Split(' ');
                    var count = int.Parse(marbleParts[0]);
                    var color = marbleParts[1].Trim();
                    return new MarbleCount(color, count);
                }
            ));

        return new Game(gameIndex, sets);
    }

    private record Game(int Index, IEnumerable<IEnumerable<MarbleCount>> Sets);

    private record MarbleCount(string Color, int Count);
}