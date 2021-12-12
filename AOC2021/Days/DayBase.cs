namespace AOC2021.Days;

public abstract class DayBase<TData>
{
    public TData FakeData => Parse(File.ReadAllText($"Data\\Fake\\{GetType().Name}.txt"));
    public TData RealData => Parse(File.ReadAllText($"Data\\Real\\{GetType().Name}.txt"));

    public abstract long Puzzle1(TData data);
    public abstract long Puzzle2(TData data);

    protected abstract TData Parse(string input);
}
