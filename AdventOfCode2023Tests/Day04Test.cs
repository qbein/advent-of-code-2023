using AdventOfCode2023;

namespace AdventOfCode2023Tests;

public class Day04Test
{
    [Fact]
    public async Task Day0401_sample_solve()
    {
        Assert.Equal(
            13,
            Day04.SolvePart01(
                await File.ReadAllLinesAsync("Files/Day0401-sample.txt")
            )
        );
    }
    
    [Fact]
    public async Task Day0401_solve()
    {
        Assert.Equal(
            21213,
            Day04.SolvePart01(
                await File.ReadAllLinesAsync("Files/Day0401.txt")
            )
        );
    }
}