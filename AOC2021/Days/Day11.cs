namespace AOC2021.Days;

public class Day11 : DayBase<int[][]>
{
    public override long Puzzle1(int[][] data)
    {
        var result = 0;

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < data.Length; j++)
            {
                for (int k = 0; k < data[j].Length; k++)
                {
                    data[j][k]++;
                }
            }

            // foreach one:
            // if its > 9, set to -1 and inc all adjacent that are not -1
            // loop through again, and again, until no explosions are found.

            while (true)
            {
                var explosion = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    for (int k = 0; k < data[j].Length; k++)
                    {
                        if (data[j][k] <= 9) continue;
                        explosion++;
                        data[j][k] = -1;

                        if (j != 0 && k != 0 && data[j - 1][k - 1] != -1)
                            data[j - 1][k - 1]++;
                        if (j != 0 && data[j - 1][k] != -1)
                            data[j - 1][k]++;
                        if (j != 0 && k != data[j].Length - 1 && data[j - 1][k + 1] != -1)
                            data[j - 1][k + 1]++;
                        if (k != 0 && data[j][k - 1] != -1)
                            data[j][k - 1]++;
                        if (k != data[j].Length - 1 && data[j][k + 1] != -1)
                            data[j][k + 1]++;
                        if (j != data.Length - 1 && k != 0 && data[j + 1][k - 1] != -1)
                            data[j + 1][k - 1]++;
                        if (j != data.Length - 1 && data[j + 1][k] != -1)
                            data[j + 1][k]++;
                        if (j != data.Length - 1 && k != data[j].Length - 1 && data[j + 1][k + 1] != -1)
                            data[j + 1][k + 1]++;
                    }
                }

                if (explosion != 0)
                    result += explosion;
                else
                    break;
            }

            for (int j = 0; j < data.Length; j++)
            {
                for (int k = 0; k < data[j].Length; k++)
                {
                    if (data[j][k] == -1)
                        data[j][k] = 0;
                }
            }
        }

        return result;
    }

    public override long Puzzle2(int[][] data)
    {
        for (int i = 0; ; i++)
        {
            for (int j = 0; j < data.Length; j++)
            {
                for (int k = 0; k < data[j].Length; k++)
                {
                    data[j][k]++;
                }
            }

            // foreach one:
            // if its > 9, set to -1 and inc all adjacent that are not -1
            // loop through again, and again, until no explosions are found.

            while (true)
            {
                var explosion = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    for (int k = 0; k < data[j].Length; k++)
                    {
                        if (data[j][k] <= 9) continue;
                        explosion++;
                        data[j][k] = -1;

                        if (j != 0 && k != 0 && data[j - 1][k - 1] != -1)
                            data[j - 1][k - 1]++;
                        if (j != 0 && data[j - 1][k] != -1)
                            data[j - 1][k]++;
                        if (j != 0 && k != data[j].Length - 1 && data[j - 1][k + 1] != -1)
                            data[j - 1][k + 1]++;
                        if (k != 0 && data[j][k - 1] != -1)
                            data[j][k - 1]++;
                        if (k != data[j].Length - 1 && data[j][k + 1] != -1)
                            data[j][k + 1]++;
                        if (j != data.Length - 1 && k != 0 && data[j + 1][k - 1] != -1)
                            data[j + 1][k - 1]++;
                        if (j != data.Length - 1 && data[j + 1][k] != -1)
                            data[j + 1][k]++;
                        if (j != data.Length - 1 && k != data[j].Length - 1 && data[j + 1][k + 1] != -1)
                            data[j + 1][k + 1]++;
                    }
                }

                if (explosion == 0)
                    break;
            }

            if (data.All(x => x.All(y => y == -1)))
                return i + 1;

            for (int j = 0; j < data.Length; j++)
            {
                for (int k = 0; k < data[j].Length; k++)
                {
                    if (data[j][k] == -1)
                        data[j][k] = 0;
                }
            }
        }
    }

    protected override int[][] Parse(string input) =>
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Select(y => int.Parse(y.ToString())).ToArray())
            .ToArray();
}
