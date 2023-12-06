using AdventOfCode2023;

namespace AdventOfCode2023Tests;

public class Day05Test
{
    [Fact]
    public async Task Day0501_sample_solve()
    {
        Assert.Equal(
            35,
            Day05.SolvePart01(
                await File.ReadAllLinesAsync("Files/Day0501-sample.txt")
            )
        );
    }
    
    [Fact]
    public async Task Day0501_solve()
    {
        Assert.Equal(
            175622908,
            Day05.SolvePart01(
                await File.ReadAllLinesAsync("Files/Day0501.txt")
            )
        );
    }
}