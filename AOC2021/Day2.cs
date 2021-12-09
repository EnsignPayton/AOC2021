namespace AOC2021;

public static class Day2
{
    public static (Direction, int)[] RealData() => File.ReadAllLines("Day2.txt").Select(ParseLine).ToArray();

    public static (Direction, int)[] FakeData() => new[]
    {
        (Direction.Forward, 5),
        (Direction.Down, 5),
        (Direction.Forward, 8),
        (Direction.Up, 3),
        (Direction.Down, 8),
        (Direction.Forward, 2),
    };

    public static int Puzzle1((Direction, int)[] data)
    {
        var hPos = 0;
        var vPos = 0;

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Item1 == Direction.Forward)
                hPos += data[i].Item2;
            else if (data[i].Item1 == Direction.Down)
                vPos += data[i].Item2;
            else if (data[i].Item1 == Direction.Up)
                vPos -= data[i].Item2;
        }

        return hPos * vPos;
    }

    public static int Puzzle2((Direction, int)[] data)
    {
        var hPos = 0;
        var vPos = 0;
        var aim = 0;

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Item1 == Direction.Forward)
            {
                hPos += data[i].Item2;
                vPos += data[i].Item2 * aim;
            }
            else if (data[i].Item1 == Direction.Down)
            {
                aim += data[i].Item2;
            }
            else if (data[i].Item1 == Direction.Up)
            {
                aim -= data[i].Item2;
            }
        }

        return hPos * vPos;
    }

    private static (Direction, int) ParseLine(string value)
    {
        var split = value.Split(' ');
        if (split.Length != 2) throw new FormatException();
        var dir = Enum.Parse<Direction>(split[0], true);
        var val = int.Parse(split[1]);
        return (dir, val);
    }

    public enum Direction
    {
        Up, Down, Forward
    }
}
