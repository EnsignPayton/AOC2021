namespace AOC2021.Days;

public class Day07 : DayBase<int[]>
{
    public override long Puzzle1(int[] data)
    {
        var min = data.Min();
        var max = data.Max();
        var smallest = int.MaxValue;

        for (int i = min; i <= max; i++)
        {
            var size = data.Select(x => Math.Abs(x - i)).Sum();
            if (size < smallest)
                smallest = size;
        }

        return smallest;
    }

    public override long Puzzle2(int[] data)
    {
        var min = data.Min();
        var max = data.Max();
        var smallest = int.MaxValue;

        for (int i = min; i <= max; i++)
        {
            var size = data.Select(x => Triangle(Math.Abs(x - i))).Sum();
            if (size < smallest)
                smallest = size;
        }

        return smallest;
    }

    private static int Triangle(int n) => BinomCoeff(n + 1, 2);

    private static int BinomCoeff(int n, int k)
    {
        var result = 1;
        for (int i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }

        return result;
    }

    protected override int[] Parse(string input) =>
        input.Trim().Split(',').Select(int.Parse).ToArray();
}
