using AdventOfCode2023;

namespace AdventOfCode2023Tests;

public class Day01Test
{
    [Fact]
    public async Task Day0101_sample_solve()
    {
        Assert.Equal(
            142,
            Day01.SolvePart01(await File.ReadAllLinesAsync("Files/Day0101-sample.txt"))
        );
    }
    
    [Fact]
    public async Task Day0101_solve()
    {
        Assert.Equal(
            54388,
            Day01.SolvePart01(await File.ReadAllLinesAsync("Files/Day0101.txt"))
        );
    }

    [Fact]
    public async Task Day0102_sample_solve()
    {
        Assert.Equal(
            281,
            Day01.SolvePart02(await File.ReadAllLinesAsync("Files/Day0102-sample.txt"))
        );
    }
    
    [Fact]
    public async Task Day0102_solve()
    {
        Assert.Equal(
            53515,
            Day01.SolvePart02(await File.ReadAllLinesAsync("Files/Day0102.txt"))
        );
    }
}