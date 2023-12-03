using AdventOfCode2023;

namespace AdventOfCode2023Tests;

public class Day02Test
{
    [Fact]
    public async Task Day0201_sample_solve()
    {
        Assert.Equal(
            8,
            Day02.SolvePart01(
                await File.ReadAllLinesAsync("Files/Day0201-sample.txt"),
                new Dictionary<string, int>
                {
                    { "red", 12 },
                    { "green", 13 },
                    { "blue", 14 },
                })
        );
    }
    
    [Fact]
    public async Task Day0201_solve()
    {
        Assert.Equal(
            2061,
            Day02.SolvePart01(
                await File.ReadAllLinesAsync("Files/Day0201.txt"),
                new Dictionary<string, int>
                {
                    { "red", 12 },
                    { "green", 13 },
                    { "blue", 14 },
                })
        );
    }
    
    [Fact]
    public async Task Day0202_sample_solve()
    {
        Assert.Equal(
            2286,
            Day02.SolvePart02(
                await File.ReadAllLinesAsync("Files/Day0201-sample.txt")
            )
        );
    }
    
    [Fact]
    public async Task Day0202_solve()
    {
        Assert.Equal(
            72596,
            Day02.SolvePart02(
                await File.ReadAllLinesAsync("Files/Day0201.txt")
            )
        );
    }
}