namespace AOC2021.Days;

public class Day5 : DayBase<Day5.Line[]>
{
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

    public override long Puzzle1(Line[] data)
    {
        var maxX = data.Max(x => Math.Max(x.X0, x.X1)) + 1;
        var maxY = data.Max(x => Math.Max(x.Y0, x.Y1)) + 1;
        var board = new int[maxY][];
        for (int i = 0; i < maxY; i++)
            board[i] = new int[maxX];

        foreach (var line in data)
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

    public override long Puzzle2(Line[] data)
    {
        var maxX = data.Max(x => Math.Max(x.X0, x.X1)) + 1;
        var maxY = data.Max(x => Math.Max(x.Y0, x.Y1)) + 1;
        var board = new int[maxY][];
        for (int i = 0; i < maxY; i++)
            board[i] = new int[maxX];

        foreach (var line in data)
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

    protected override Line[] Parse(string input) =>
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(Line.Parse)
            .ToArray();
}
