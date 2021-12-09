namespace AOC2021.Days;

public abstract class DayBase<TData>
{
    public TData FakeData => Parse(File.ReadAllText($"Data\\Fake\\{GetType().Name}.txt"));
    public TData RealData => Parse(File.ReadAllText($"Data\\Real\\{GetType().Name}.txt"));

    public abstract int Puzzle1(TData data);
    public abstract int Puzzle2(TData data);

    protected abstract TData Parse(string input);
}
