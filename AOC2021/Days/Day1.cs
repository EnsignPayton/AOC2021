namespace AOC2021.Days;

public class Day1 : DayBase<int[]>
{
    public override int Puzzle1(int[] data)
    {
        var result = 0;

        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] > data[i - 1])
                result++;
        }

        return result;
    }

    public override int Puzzle2(int[] data)
    {
        var result = 0;

        for (int i = 3; i < data.Length; i++)
        {
            var sumLeft = data[i - 3] + data[i - 2] + data[i - 1];
            var sumRight = data[i - 2] + data[i - 1] + data[i];
            if (sumLeft < sumRight)
                result++;
        }

        return result;
    }

    protected override int[] Parse(string input) =>
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
}
