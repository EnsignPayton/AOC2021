namespace AOC2021;

public static class Lanternfish
{
    public static int CalcTrivial(int a, int b, int t, IEnumerable<int> data)
    {
        var list = data.ToList();

        for (int i = 0; i < t; i++)
        {
            var count = list.Count;
            for (int j = 0; j < count; j++)
            {
                if (list[j] == 0)
                {
                    list[j] = a - 1;
                    list.Add(b - 1);
                }
                else
                {
                    list[j]--;
                }
            }
        }

        return list.Count;
    }

    public static long Calc(int a, int b, int t, IEnumerable<int> data)
    {
        return data.Select(x => Calc(a, b, t, x)).Sum();
    }

    public static long Calc(int a, int b, int t, int s)
    {
        return Calc(a, b, t - s);
    }

    public static long Calc(int a, int b, int t)
    {
        if (t == 0) return 1;

        var result = new long[t];

        for (int i = 0; i < t; i++)
        {
            var iA = i - a;
            var iB = i - b;
            var xA = iA < 0 ? 1 : result[iA];
            var xB = iB < 0 ? 1 : result[iB];
            result[i] = xA + xB;
        }

        return result[t - 1];
    }
}
