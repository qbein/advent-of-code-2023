using AdventOfCode2023;

namespace AdventOfCode2023Tests;

public class Day01Test
{
    [Fact]
    public async Task Day01_sample_solve()
    {
        Assert.Equal(142, Day01.Solve(await File.ReadAllLinesAsync("Files/Day01-sample.txt")));
    }
    
    [Fact]
    public async Task Day01_solve()
    {
        Assert.Equal(54388, Day01.Solve(await File.ReadAllLinesAsync("Files/Day01.txt")));
    }
}