namespace AOC2021.Days;

public class Day06 : DayBase<int[]>
{
    public override long Puzzle1(int[] data)
    {
        return Lanternfish.CalcTrivial(7, 9, 80, data);
    }

    public override long Puzzle2(int[] data)
    {
        return Lanternfish.Calc(7, 9, 256, data);
    }

    protected override int[] Parse(string input) =>
        input.Trim().Split(',').Select(int.Parse).ToArray();
}
