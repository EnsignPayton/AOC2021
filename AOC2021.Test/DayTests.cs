using AOC2021.Days;
using Xunit;

namespace AOC2021.Test;

public class DayTests
{
    [Fact]
    public void Day1Puzzle1()
    {
        AssertPuzzle1(7, new Day1());
    }

    [Fact]
    public void Day1Puzzle2()
    {
        AssertPuzzle2(5, new Day1());
    }

    [Fact]
    public void Day2Puzzle1()
    {
        AssertPuzzle1(150, new Day2());
    }

    [Fact]
    public void Day2Puzzle2()
    {
        AssertPuzzle2(900, new Day2());
    }

    [Fact]
    public void Day3Puzzle1()
    {
        AssertPuzzle1(198, new Day3());
    }

    [Fact]
    public void Day3Puzzle2()
    {
        AssertPuzzle2(230, new Day3());
    }

    [Fact]
    public void Day4Puzzle1()
    {
        AssertPuzzle1(4512, new Day4());
    }

    [Fact]
    public void Day4Puzzle2()
    {
        AssertPuzzle2(1924, new Day4());
    }

    [Fact]
    public void Day5Puzzle1()
    {
        AssertPuzzle1(5, new Day5());
    }

    [Fact]
    public void Day5Puzzle2()
    {
        AssertPuzzle2(12, new Day5());
    }

    [Fact]
    public void Day6Puzzle1()
    {
        AssertPuzzle1(5934, new Day6());
    }

    [Fact]
    public void Day6Puzzle2()
    {
        AssertPuzzle2(26984457539, new Day6());
    }

    [Fact]
    public void Day7Puzzle1()
    {
        AssertPuzzle1(37, new Day7());
    }

    [Fact]
    public void Day7Puzzle2()
    {
        AssertPuzzle2(168, new Day7());
    }

    [Fact]
    public void Day8Puzzle1()
    {
        AssertPuzzle1(26, new Day8());
    }

    [Fact]
    public void Day8Puzzle2()
    {
        AssertPuzzle2(61229, new Day8());
    }

    [Fact]
    public void Day9Puzzle1()
    {
        AssertPuzzle1(15, new Day9());
    }

    [Fact]
    public void Day9Puzzle2()
    {
        AssertPuzzle2(1134, new Day9());
    }

    private static void AssertPuzzle1<TData>(long expected, DayBase<TData> day)
    {
        var result = day.Puzzle1(day.FakeData);
        Assert.Equal(expected, result);
    }

    private static void AssertPuzzle2<TData>(long expected, DayBase<TData> day)
    {
        var result = day.Puzzle2(day.FakeData);
        Assert.Equal(expected, result);
    }
}
