namespace AOC2021.Days;

public class Day12 : DayBase<Day12.Graph>
{
    public record Pair(string Node1, string Node2)
    {
        public static Pair Parse(string value)
        {
            var split = value.Split('-', StringSplitOptions.TrimEntries);
            return new Pair(split[0], split[1]);
        }
    }

    public record Graph(string[] Vertices, Pair[] Edges)
    {
        public static Graph Parse(Pair[] data)
        {
            var vertices = new List<string>();

            foreach (var (node1, node2) in data)
            {
                if (!vertices.Contains(node1))
                    vertices.Add(node1);
                if (!vertices.Contains(node2))
                    vertices.Add(node2);
            }

            return new Graph(vertices.ToArray(), data.ToArray());
        }

        public IEnumerable<string> GetAdjacent(string vertex)
        {
            foreach (var (node1, node2) in Edges)
            {
                if (node1 == vertex)
                    yield return node2;
                else if (node2 == vertex)
                    yield return node1;
            }
        }
    }

    public override long Puzzle1(Graph data)
    {
        return CaveSearch1(data).Count;
    }

    public override long Puzzle2(Graph data)
    {
        return CaveSearch2(data).Count;
    }

    private static List<List<string>> CaveSearch1(Graph graph)
    {
        const string start = "start";
        const string end = "end";
        var visited = new List<string>();
        var path = new List<string>();
        var paths = new List<List<string>>();
        path.Add(start);

        RecursiveCaveSearch1(graph, start, end, visited, path, paths);

        return paths;
    }

    private static void RecursiveCaveSearch1(
        Graph graph,
        string curr,
        string dest,
        ICollection<string> visited,
        ICollection<string> path,
        ICollection<List<string>> paths)
    {
        if (curr == dest)
        {
            paths.Add(path.ToList());
            return;
        }

        if (curr.All(char.IsLower))
            visited.Add(curr);

        foreach (var vertex in graph.GetAdjacent(curr))
        {
            if (visited.Contains(vertex)) continue;

            path.Add(curr);
            RecursiveCaveSearch1(graph, vertex, dest, visited, path, paths);
            path.Remove(curr);
        }

        visited.Remove(curr);
    }

    private static List<List<string>> CaveSearch2(Graph graph)
    {
        const string start = "start";
        const string end = "end";
        var visited = new List<string>();
        var path = new List<string>();
        var paths = new List<List<string>>();
        path.Add(start);

        var secondVisit = string.Empty;
        RecursiveCaveSearch2(graph, start, end, visited, path, paths, ref secondVisit);

        return paths;
    }

    private static void RecursiveCaveSearch2(
        Graph graph,
        string curr,
        string dest,
        ICollection<string> visited,
        ICollection<string> path,
        ICollection<List<string>> paths,
        ref string secondVisit)
    {
        if (curr == dest)
        {
            paths.Add(path.ToList());
            return;
        }

        if (curr.All(char.IsLower))
            visited.Add(curr);

        foreach (var vertex in graph.GetAdjacent(curr))
        {
            if (visited.Contains(vertex))
            {
                if (vertex != "start" && vertex != "end" && secondVisit == string.Empty)
                    secondVisit = vertex;
                else
                    continue;
            }

            path.Add(curr);
            RecursiveCaveSearch2(graph, vertex, dest, visited, path, paths, ref secondVisit);
            path.Remove(curr);
        }

        if (secondVisit == curr)
            secondVisit = string.Empty;
        visited.Remove(curr);
    }

    protected override Graph Parse(string input) => Graph.Parse(
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(Pair.Parse).ToArray());
}
