using Xunit;

namespace AOC2021.Test;

public class LanternfishTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 2)]
    [InlineData(1, 3)]
    [InlineData(2, 3)]
    [InlineData(3, 3)]
    [InlineData(1, 4)]
    [InlineData(2, 4)]
    [InlineData(3, 4)]
    [InlineData(4, 4)]
    [InlineData(1, 5)]
    [InlineData(2, 5)]
    [InlineData(3, 5)]
    [InlineData(4, 5)]
    [InlineData(5, 5)]
    public void T0IsAlways1(int a, int b)
    {
        var result = Lanternfish.Calc(a, b, 0);
        Assert.Equal(1, result);
    }

    [Theory]
    [InlineData(1, 1, 1, 2)]
    [InlineData(1, 1, 2, 4)]
    [InlineData(1, 1, 3, 8)]
    [InlineData(1, 1, 4, 16)]
    [InlineData(1, 2, 1, 2)]
    [InlineData(1, 2, 2, 3)]
    [InlineData(1, 2, 3, 5)]
    [InlineData(1, 2, 4, 8)]
    [InlineData(2, 2, 1, 2)]
    [InlineData(2, 2, 2, 2)]
    [InlineData(2, 2, 3, 4)]
    [InlineData(2, 2, 4, 4)]
    [InlineData(1, 3, 1, 2)]
    [InlineData(1, 3, 2, 3)]
    [InlineData(1, 3, 3, 4)]
    [InlineData(1, 3, 4, 6)]
    [InlineData(2, 3, 1, 2)]
    [InlineData(2, 3, 2, 2)]
    [InlineData(2, 3, 3, 3)]
    [InlineData(2, 3, 4, 4)]
    [InlineData(3, 3, 1, 2)]
    [InlineData(3, 3, 2, 2)]
    [InlineData(3, 3, 3, 2)]
    [InlineData(3, 3, 4, 4)]
    [InlineData(1, 4, 1, 2)]
    [InlineData(1, 4, 2, 3)]
    [InlineData(1, 4, 3, 4)]
    [InlineData(1, 4, 4, 5)]
    [InlineData(2, 4, 1, 2)]
    [InlineData(2, 4, 2, 2)]
    [InlineData(2, 4, 3, 3)]
    [InlineData(2, 4, 4, 3)]
    public void TestCalc(int a, int b, int t, int expected)
    {
        var result = Lanternfish.Calc(a, b, t);
        Assert.Equal(expected, result);
    }
}
