Console.WriteLine("Day | Puzzle 1 Value       | Puzzle 2 Value");
Console.WriteLine("--- | -------------------- | --------------------");

var types = typeof(AOC2021.Days.DayBase<>).Assembly.GetTypes();

for (int i = 1; i <= 25; i++)
{
    var type = types.SingleOrDefault(x => x.Name.EndsWith($"Day{i:D2}"));
    if (type == null) break;

    var instance = Activator.CreateInstance(type);

    var dataProp = type.GetProperty("RealData")!;
    var data = dataProp.GetValue(instance);

    var method1 = type.GetMethod("Puzzle1")!;
    object? result1;
    try
    {
        result1 = method1.Invoke(instance, new[] { data });
    }
    catch (NotImplementedException)
    {
        result1 = "Not Implemented";
    }

    var method2 = type.GetMethod("Puzzle2")!;
    object? result2;
    try
    {
        result2 = method2.Invoke(instance, new[] { data });
    }
    catch (NotImplementedException)
    {
        result2 = "Not Implemented";
    }

    Console.WriteLine($"{i,3} | {result1,20} | {result2,20}");
}

Console.WriteLine("--- | -------------------- | --------------------");
Console.WriteLine("Done.");
