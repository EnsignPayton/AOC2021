using AOC2021.Days;
using Xunit;

namespace AOC2021.Test;

public class DayTests
{
    [Theory]
    [InlineData(1, 1, 7)]
    [InlineData(1, 2, 5)]
    [InlineData(2, 1, 150)]
    [InlineData(2, 2, 900)]
    [InlineData(3, 1, 198)]
    [InlineData(3, 2, 230)]
    [InlineData(4, 1, 4512)]
    [InlineData(4, 2, 1924)]
    [InlineData(5, 1, 5)]
    [InlineData(5, 2, 12)]
    [InlineData(6, 1, 5934)]
    [InlineData(6, 2, 26984457539)]
    [InlineData(7, 1, 37)]
    [InlineData(7, 2, 168)]
    [InlineData(8, 1, 26)]
    [InlineData(8, 2, 61229)]
    [InlineData(9, 1, 15)]
    [InlineData(9, 2, 1134)]
    [InlineData(10, 1, 26397)]
    [InlineData(10, 2, 288957)]
    [InlineData(11, 1, 1656)]
    [InlineData(11, 2, 195)]
    [InlineData(12, 1, 10)]
    [InlineData(12, 2, 36)]
    public void TestPuzzle(int day, int num, long expected)
    {
        var type = typeof(DayBase<>).Assembly.GetTypes()
            .Single(x => x.Name.EndsWith($"Day{day:D2}"));

        var instance = Activator.CreateInstance(type);

        var dataProp = type.GetProperty("FakeData")!;
        var data = dataProp.GetValue(instance);

        var method = type.GetMethod("Puzzle" + num)!;

        var result = method.Invoke(instance, new[]{data});

        Assert.Equal(expected, result);
    }
}
