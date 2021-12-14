namespace AOC2021.Days;

public class Day09 : DayBase<int[][]>
{
    public override long Puzzle1(int[][] data)
    {
        var lows = new List<int>();
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                var val = data[i][j];
                var left = j == 0 || data[i][j - 1] > val;
                var up = i == 0 || data[i - 1][j] > val;
                var right = j == data[i].Length - 1 || data[i][j + 1] > val;
                var down = i == data.Length - 1 || data[i + 1][j] > val;

                if (left && up && right && down) lows.Add(val);
            }
        }

        return lows
            .Select(x => x + 1)
            .Sum();
    }

    public override long Puzzle2(int[][] data)
    {
        var basins = new List<int>();
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                var val = data[i][j];
                if (val is -1 or 9) continue;

                var size = 0;
                ScanBasins(data, i, j, ref size);
                basins.Add(size);
            }
        }

        return basins
            .OrderByDescending(x => x)
            .Take(3)
            .Aggregate(1, (current, bar) => current * bar);
    }

    private static void ScanBasins(int[][] data, int i, int j, ref int size)
    {
        var pois = new List<(int, int)>();
        void Add(int x, int y)
        {
            if (!pois.Contains((x, y)))
                pois.Add((x, y));
        }

        var val = data[i][j];
        if (val is -1 or 9) return;

        size++;
        data[i][j] = -1;

        if (j != 0) Add(i, j - 1);
        if (i != 0) Add(i - 1, j);
        if (j != data[i].Length - 1) Add(i, j + 1);
        if (i != data.Length - 1) Add(i + 1, j);

        foreach (var (x, y) in pois)
            ScanBasins(data, x, y, ref size);
    }

    protected override int[][] Parse(string input) =>
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Select(y => int.Parse(y.ToString())).ToArray())
            .ToArray();
}
