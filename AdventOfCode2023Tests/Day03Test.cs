using AdventOfCode2023;

namespace AdventOfCode2023Tests;

public class Day03Test
{
    [Fact]
    public async Task Day0301_sample_solve()
    {
        Assert.Equal(
            4361,
            Day03.SolvePart01(
                await File.ReadAllLinesAsync("Files/Day0301-sample.txt")
            )
        );
    }
    
    [Fact]
    public async Task Day0301_solve()
    {
        Assert.Equal(
            527144,
            Day03.SolvePart01(
                await File.ReadAllLinesAsync("Files/Day0301.txt")
            )
        );
    }
}