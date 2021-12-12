namespace AOC2021.Days;

public class Day4 : DayBase<Day4.Bingo>
{
    public class Bingo
    {
        public int[] Calls { get; }

        public int[][][] Boards { get; }

        private Bingo(int[] calls, int[][][] boards)
        {
            Calls = calls;
            Boards = boards;
        }

        public static Bingo Parse(string value)
        {
            // Assuming 5x5
            var lines = value.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var calls = lines[0].Split(',').Select(int.Parse).ToArray();
            var boards = new List<int[][]>();

            for (int i = 1; i < lines.Length - 4; i += 5)
            {
                var board = new int[5][];
                for (int j = 0; j < 5; j++)
                {
                    var row = lines[i + j].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    board[j] = row;
                }

                boards.Add(board);
            }

            return new Bingo(calls, boards.ToArray());
        }
    }

    public override long Puzzle1(Bingo data)
    {
        foreach (var call in data.Calls)
        {
            // Check call
            foreach (var board in data.Boards)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[i][j] == call)
                            board[i][j] = -1;
                    }
                }
            }

            // Check boards for winners
            int winner = -1;
            for (int iBoard = 0; iBoard < data.Boards.Length; iBoard++)
            {
                // Check rows first
                for (int i = 0; i < 5; i++)
                {
                    if (data.Boards[iBoard][i].All(x => x == -1))
                        winner = iBoard;
                }

                for (int j = 0; j < 5; j++)
                {
                    var tCount = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (data.Boards[iBoard][i][j] == -1)
                            tCount++;
                    }

                    if (tCount == 5)
                        winner = iBoard;
                }

                if (winner != -1) break;
            }

            if (winner != -1)
            {
                // Sum of unmarked
                var score = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (data.Boards[winner][i][j] != -1)
                            score += data.Boards[winner][i][j];
                    }
                }

                return score * call;
            }
        }

        return 0;
    }

    public override long Puzzle2(Bingo data)
    {
        var scores = new List<int>();
        var ignoredBoards = new List<int>();
        foreach (var call in data.Calls)
        {
            // Check call
            for (int iBoard = 0; iBoard < data.Boards.Length; iBoard++)
            {
                if (ignoredBoards.Contains(iBoard)) continue;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (data.Boards[iBoard][i][j] == call)
                            data.Boards[iBoard][i][j] = -1;
                    }
                }
            }

            // Check boards for winners
            var winners = new List<int>();
            for (int iBoard = 0; iBoard < data.Boards.Length; iBoard++)
            {
                if (ignoredBoards.Contains(iBoard)) continue;
                // Check rows first
                for (int i = 0; i < 5; i++)
                {
                    if (data.Boards[iBoard][i].All(x => x == -1))
                        winners.Add(iBoard);
                }

                for (int j = 0; j < 5; j++)
                {
                    var tCount = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (data.Boards[iBoard][i][j] == -1)
                            tCount++;
                    }

                    if (tCount == 5)
                        winners.Add(iBoard);
                }
            }

            foreach (var winner in winners)
            {
                // Sum of unmarked
                var score = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (data.Boards[winner][i][j] != -1)
                            score += data.Boards[winner][i][j];
                    }
                }

                if (score == 0)
                    throw new Exception("Stupid alert");

                scores.Add(score * call);
                ignoredBoards.Add(winner);
            }

            if (ignoredBoards.Count == data.Boards.Length) break;
        }

        return scores.LastOrDefault();
    }

    protected override Bingo Parse(string input)
    {
        return Bingo.Parse(input);
    }
}
