using AdventOfCode2023;

namespace AdventOfCode2023Tests;

public class StringExtensionTest
{
    [Theory]
    [InlineData("eighthree", "83")]
    [InlineData("sevenine", "79")]
    [InlineData("sevennine", "79")]
    [InlineData("eightthree", "83")]
    public void CollapseNumbers(string input, string output)
    {
        Assert.Equal(output, input.CollapseNumbers());
    }
}