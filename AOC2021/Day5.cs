namespace AOC2021;

public static class Day5
{
    private const string Example = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

    public static Line[] RealData() => File.ReadAllLines("Day5.txt")
        .Select(Line.Parse).ToArray();

    public static Line[] FakeData() => Example.Split(Environment.NewLine)
        .Select(Line.Parse).ToArray();

    public static int Puzzle1(Line[] value)
    {
        var maxX = value.Max(x => Math.Max(x.X0, x.X1)) + 1;
        var maxY = value.Max(x => Math.Max(x.Y0, x.Y1)) + 1;
        var board = new int[maxY][];
        for (int i = 0; i < maxY; i++)
            board[i] = new int[maxX];

        foreach (var line in value)
        {
            // Ignore diagonals
            if (line.X0 != line.X1 && line.Y0 != line.Y1) continue;

            if (line.X0 == line.X1)
            {
                // Vertical
                var min = Math.Min(line.Y0, line.Y1);
                var max = Math.Max(line.Y0, line.Y1);

                for (int i = min; i <= max; i++)
                {
                    board[i][line.X0]++;
                }
            }
            else
            {
                var min = Math.Min(line.X0, line.X1);
                var max = Math.Max(line.X0, line.X1);

                for (int i = min; i <= max; i++)
                {
                    board[line.Y0][i]++;
                }
            }
        }

        var count = 0;
        for (int i = 0; i < maxY; i++)
        {
            for (int j = 0; j < maxX; j++)
            {
                if (board[i][j] > 1) count++;
            }
        }

        return count;
    }

    public static int Puzzle2(Line[] value)
    {
        var maxX = value.Max(x => Math.Max(x.X0, x.X1)) + 1;
        var maxY = value.Max(x => Math.Max(x.Y0, x.Y1)) + 1;
        var board = new int[maxY][];
        for (int i = 0; i < maxY; i++)
            board[i] = new int[maxX];

        foreach (var line in value)
        {
            // Diagonals
            if (line.X0 != line.X1 && line.Y0 != line.Y1)
            {
                var xmin = Math.Min(line.X0, line.X1);
                var xmax = Math.Max(line.X0, line.X1);
                var ymin = Math.Min(line.Y0, line.Y1);
                var ymax = Math.Max(line.Y0, line.Y1);

                var samedir = (line.X0 < line.X1 && line.Y0 < line.Y1) ||
                              (line.X0 > line.X1 && line.Y0 > line.Y1);

                for (int i = 0; i <= ymax - ymin; i++)
                {
                    board[i + ymin][samedir ? xmin + i : xmax - i]++;
                }
            }
            else if (line.X0 == line.X1)
            {
                // Vertical
                var min = Math.Min(line.Y0, line.Y1);
                var max = Math.Max(line.Y0, line.Y1);

                for (int i = min; i <= max; i++)
                {
                    board[i][line.X0]++;
                }
            }
            else
            {
                var min = Math.Min(line.X0, line.X1);
                var max = Math.Max(line.X0, line.X1);

                for (int i = min; i <= max; i++)
                {
                    board[line.Y0][i]++;
                }
            }
        }

        var count = 0;
        for (int i = 0; i < maxY; i++)
        {
            for (int j = 0; j < maxX; j++)
            {
                if (board[i][j] > 1) count++;
            }
        }

        return count;
    }

    public record Line(int X0, int Y0, int X1, int Y1)
    {
        public static Line Parse(string value)
        {
            var pos = value.IndexOf("->", StringComparison.Ordinal);
            var start = value[..pos].Trim().Split(',').Select(int.Parse).ToList();
            var end = value[(pos + 2)..].Trim().Split(',').Select(int.Parse).ToList();
            return new Line(start[0], start[1], end[0], end[1]);
        }
    }
}
