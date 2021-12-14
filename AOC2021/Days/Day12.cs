namespace AOC2021.Days;

public class Day12 : DayBase<Day12.Pair[]>
{
    public record Pair(string Node1, string Node2)
    {
        public static Pair Parse(string value)
        {
            var split = value.Split('-', StringSplitOptions.TrimEntries);
            return new Pair(split[0], split[1]);
        }
    }

    private class GraphVisitor
    {
        private const string Start = "start";
        private const string End = "end";

        private readonly List<string> _visited = new();
        private readonly List<string> _path = new();
        private readonly List<List<string>> _paths = new();

        private string _secondVisit = string.Empty;

        public List<List<string>> Search1(Pair[] pairs)
        {
            Clear();
            RecursiveSearch(pairs, Start, x => _visited.Contains(x), _ => { });
            return _paths.ToList();
        }

        public List<List<string>> Search2(Pair[] pairs)
        {
            bool VertexVisited(string vertex)
            {
                if (_visited.Contains(vertex))
                {
                    if (vertex != Start && vertex != End && _secondVisit == string.Empty)
                        _secondVisit = vertex;
                    else
                        return true;
                }

                return false;
            }

            void AfterVisit(string curr)
            {
                if (_secondVisit == curr)
                    _secondVisit = string.Empty;
            }

            Clear();
            RecursiveSearch(pairs, Start, VertexVisited, AfterVisit);
            return _paths.ToList();
        }

        private void Clear()
        {
            _visited.Clear();
            _path.Clear();
            _paths.Clear();
            _secondVisit = string.Empty;
        }

        private void RecursiveSearch(Pair[] pairs, string curr, Func<string, bool> vertexVisited, Action<string> afterVisit)
        {
            if (curr == End)
            {
                _paths.Add(_path.ToList());
                return;
            }

            if (curr.All(char.IsLower))
                _visited.Add(curr);

            foreach (var vertex in GetAdjacent(pairs, curr))
            {
                if (vertexVisited(vertex)) continue;

                _path.Add(curr);
                RecursiveSearch(pairs, vertex, vertexVisited, afterVisit);
                _path.Remove(curr);
            }

            afterVisit(curr);
            _visited.Remove(curr);
        }
    }

    public override long Puzzle1(Pair[] data) =>
        new GraphVisitor().Search1(data).Count;

    public override long Puzzle2(Pair[] data) =>
        new GraphVisitor().Search2(data).Count;

    protected override Pair[] Parse(string input) =>
        input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(Pair.Parse)
            .ToArray();

    private static IEnumerable<string> GetAdjacent(IEnumerable<Pair> pairs, string vertex)
    {
        foreach (var (node1, node2) in pairs)
        {
            if (node1 == vertex)
                yield return node2;
            else if (node2 == vertex)
                yield return node1;
        }
    }
}
