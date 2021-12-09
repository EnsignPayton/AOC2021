namespace AOC2021;

public static class Day1
{
    public static int[] RealData() => File.ReadAllLines("Day1.txt").Select(int.Parse).ToArray();

    public static int[] FakeData() => new[]
    {
        199, 200, 208, 210, 200, 207, 240, 269, 260, 263
    };

    public static int Puzzle1(int[] data)
    {
        var result = 0;

        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] > data[i - 1])
                result++;
        }

        return result;
    }

    public static int Puzzle2(int[] data)
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
}
