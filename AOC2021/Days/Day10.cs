namespace AOC2021.Days;

public class Day10 : DayBase<string[]>
{
    public override long Puzzle1(string[] data)
    {
        int result = 0;

        foreach (var line in data)
        {
            var stack = new Stack<char>();

            bool Match(char val) => stack!.TryPeek(out var peek) && peek == Open(val);

            foreach (var val in line)
            {
                if (val is '(' or '[' or '{' or '<')
                    stack.Push(val);
                else if (Match(val))
                    stack.Pop();
                else
                {
                    result += P1Value(val);
                    break;
                }
            }
        }

        return result;
    }

    public override long Puzzle2(string[] data)
    {
        var compScores = new List<long>();

        foreach (var line in data)
        {
            var stack = new Stack<char>();

            bool Match(char val) => stack!.TryPeek(out var peek) && peek == Open(val);

            bool corrupt = false;
            foreach (var val in line)
            {
                if (val is '(' or '[' or '{' or '<')
                    stack.Push(val);
                else if (Match(val))
                    stack.Pop();
                else
                {
                    corrupt = true;
                    break;
                }
            }

            if (corrupt) continue;
            if (stack.Count == 0) continue;

            long score = 0L;
            while (stack.Count > 0)
            {
                var val = stack.Pop();
                score = score * 5L + P2Value(val);
            }

            compScores.Add(score);
        }

        var rCount = (int)Math.Ceiling(compScores.Count / 2.0);
        return compScores.OrderBy(x => x).Take(rCount).Last();
    }

    private static char Open(char close) =>
        close switch
        {
            ')' => '(',
            ']' => '[',
            '}' => '{',
            '>' => '<',
            _ => throw new NotImplementedException()
        };

    private static int P1Value(char close) =>
        close switch
        {
            ')' => 3,
            ']' => 57,
            '}' => 1197,
            '>' => 25137,
            _ => throw new NotImplementedException()
        };

    private static int P2Value(char close) =>
        close switch
        {
            '(' => 1,
            '[' => 2,
            '{' => 3,
            '<' => 4,
            _ => throw new NotImplementedException()
        };

    protected override string[] Parse(string input) =>
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
}
