using System.Text;

namespace AOC2021.Days;

public class Day3 : DayBase<string[]>
{
    public override long Puzzle1(string[] data)
    {
        var maxpos = data.Max(x => x.Length);
        var gamma = new StringBuilder(maxpos);
        var epsilon = new StringBuilder(maxpos);

        for (int i = 0; i < maxpos; i++)
        {
            var counter = 0;
            foreach (var line in data)
            {
                if (line[i] == '1')
                    counter++;
                else
                    counter--;
            }

            if (counter > 0)
            {
                gamma.Append('1');
                epsilon.Append('0');
            }
            else
            {
                gamma.Append('0');
                epsilon.Append('1');
            }
        }

        return Convert.ToInt32(gamma.ToString(), 2) *
               Convert.ToInt32(epsilon.ToString(), 2);
    }

    public override long Puzzle2(string[] data)
    {
        var oxy = OxyBit(0, data);
        var co2 = Co2Bit(0, data);
        return Convert.ToInt32(oxy, 2) *
               Convert.ToInt32(co2, 2);
    }

    private static string OxyBit(int pos, string[] data)
    {
        if (pos >= data.Max(x => x.Length)) return string.Empty;

        var counter = 0;
        foreach (var line in data)
        {
            if (line[pos] == '1')
                counter++;
            else
                counter--;
        }

        var expected = counter >= 0 ? '1' : '0';
        var newData = data
            .Where(x => x[pos] == expected)
            .ToArray();

        if (newData.Length == 1)
            return newData[0][pos..];

        return expected + OxyBit(++pos, newData);
    }

    private static string Co2Bit(int pos, string[] data)
    {
        if (pos >= data.Max(x => x.Length)) return string.Empty;

        var counter = 0;
        foreach (var line in data)
        {
            if (line[pos] == '1')
                counter++;
            else
                counter--;
        }

        var expected = counter >= 0 ? '0' : '1';
        var newData = data
            .Where(x => x[pos] == expected)
            .ToArray();

        if (newData.Length == 1)
            return newData[0][pos..];

        return expected + Co2Bit(++pos, newData);
    }

    protected override string[] Parse(string input) =>
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
}
