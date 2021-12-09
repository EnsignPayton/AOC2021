namespace AOC2021.Days;

public class Day2 : DayBase<Day2.Vector[]>
{
    public enum Direction
    {
        Up, Down, Forward
    }

    public record Vector(Direction Direction, int Magnitude);

    public override int Puzzle1(Vector[] data)
    {
        var hPos = 0;
        var vPos = 0;

        foreach (var (direction, magnitude) in data)
        {
            if (direction == Direction.Forward)
                hPos += magnitude;
            else if (direction == Direction.Down)
                vPos += magnitude;
            else if (direction == Direction.Up)
                vPos -= magnitude;
        }

        return hPos * vPos;
    }

    public override int Puzzle2(Vector[] data)
    {
        var hPos = 0;
        var vPos = 0;
        var aim = 0;

        foreach (var (direction, magnitude) in data)
        {
            if (direction == Direction.Forward)
            {
                hPos += magnitude;
                vPos += magnitude * aim;
            }
            else if (direction == Direction.Down)
            {
                aim += magnitude;
            }
            else if (direction == Direction.Up)
            {
                aim -= magnitude;
            }
        }

        return hPos * vPos;
    }

    protected override Vector[] Parse(string input) =>
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(ParseLine)
            .ToArray();

    private static Vector ParseLine(string value)
    {
        var split = value.Split(' ');
        if (split.Length != 2) throw new FormatException();
        var dir = Enum.Parse<Direction>(split[0], true);
        var val = int.Parse(split[1]);
        return new Vector(dir, val);
    }
}
