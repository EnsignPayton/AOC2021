namespace AOC2021.Days;

public class Day8 : DayBase<Day8.Line[]>
{
    public record Line(string[] Patterns, string[] Outputs)
    {
        public static Line Parse(string value)
        {
            var split = value.Split('|', StringSplitOptions.TrimEntries);
            var patterns = split[0].Split(' ');
            var outputs = split[1].Split(' ');
            return new Line(patterns, outputs);
        }
    }

    public override long Puzzle1(Line[] data) => data
        .SelectMany(x => x.Outputs.Where(y => y is { Length: 2 or 3 or 4 or 7 }))
        .Count();

    public override long Puzzle2(Line[] data) => data.Select(GetNumber).Sum();

    private static int GetNumber(Line line)
    {
        var map = FindMap(line);
        return line.Outputs
            .Select(x => Decode(Unravel(x, map)))
            .Aggregate(0, (current, num) => current * 10 + num);
    }

    private static char[] FindMap(Line line)
    {
        var result = new char[7];

        var (patterns, _) = line;
        var t2 = patterns.Single(x => x.Length == 2);
        var t3 = patterns.Single(x => x.Length == 3);
        var t4 = patterns.Single(x => x.Length == 4);
        var t5s = patterns.Where(x => x.Length == 5).ToList();
        var t6s = patterns.Where(x => x.Length == 6).ToList();
        var t7 = patterns.Single(x => x.Length == 7);

        // a is in threes but not twos
        result['a' - 'a'] = t3.Single(x => !t2.Contains(x));

        // f is the member of t2 that appears in t6s more. The other is c.
        var firstIsF = t6s.Count(x => x.Contains(t2[0])) >
                       t6s.Count(x => x.Contains(t2[1]));

        result['f' - 'a'] = firstIsF ? t2[0] : t2[1];
        result['c' - 'a'] = firstIsF ? t2[1] : t2[0];

        // g is remaining that appears in all 5,6,7
        result['g' - 'a'] = t7.Single(x => !result.Contains(x) &&
                                           t5s.All(y => y.Contains(x)) &&
                                           t6s.All(y => y.Contains(x)));

        // e is remaining that appears in 7 but not 4
        result['e' - 'a'] = t7.Single(x => !result.Contains(x) &&
                                           !t4.Contains(x));

        // d is remaining that appears in all 5s
        result['d' - 'a'] = t7.Single(x => !result.Contains(x) &&
                                           t5s.Count(y => y.Contains(x)) == 3);

        // b is the only one left
        result['b' - 'a'] = t7.Single(x => !result.Contains(x));

        return result;
    }

    private static string Unravel(string input, char[] map) =>
        string.Join(string.Empty, input.Select(x => (char) (Array.IndexOf(map, x) + 'a')).OrderBy(x => x));

    private static int Decode(string input) => input switch
    {
        "abcefg" => 0,
        "cf" => 1,
        "acdeg" => 2,
        "acdfg" => 3,
        "bcdf" => 4,
        "abdfg" => 5,
        "abdefg" => 6,
        "acf" => 7,
        "abcdefg" => 8,
        "abcdfg" => 9,
        _ => throw new NotImplementedException()
    };

    protected override Line[] Parse(string input) =>
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(Line.Parse)
            .ToArray();
}
