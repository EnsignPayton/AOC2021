namespace AOC2021;

public static class Day4
{
    private const string Example = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

    public static Bingo RealData() => Bingo.Parse(File.ReadAllText("Day4.txt"));

    public static Bingo FakeData() => Bingo.Parse(Example);

    public static int Puzzle1(Bingo value)
    {
        foreach (var call in value.Calls)
        {
            // Check call
            foreach (var board in value.Boards)
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
            for (int iBoard = 0; iBoard < value.Boards.Length; iBoard++)
            {
                // Check rows first
                for (int i = 0; i < 5; i++)
                {
                    if (value.Boards[iBoard][i].All(x => x == -1))
                        winner = iBoard;
                }

                for (int j = 0; j < 5; j++)
                {
                    var tCount = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (value.Boards[iBoard][i][j] == -1)
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
                        if (value.Boards[winner][i][j] != -1)
                            score += value.Boards[winner][i][j];
                    }
                }

                return score * call;
            }
        }

        return 0;
    }

    public static int Puzzle2(Bingo value)
    {
        var scores = new List<int>();
        var ignoredBoards = new List<int>();
        foreach (var call in value.Calls)
        {
            // Check call
            for (int iBoard = 0; iBoard < value.Boards.Length; iBoard++)
            {
                if (ignoredBoards.Contains(iBoard)) continue;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (value.Boards[iBoard][i][j] == call)
                            value.Boards[iBoard][i][j] = -1;
                    }
                }
            }

            // Check boards for winners
            var winners = new List<int>();
            for (int iBoard = 0; iBoard < value.Boards.Length; iBoard++)
            {
                if (ignoredBoards.Contains(iBoard)) continue;
                // Check rows first
                for (int i = 0; i < 5; i++)
                {
                    if (value.Boards[iBoard][i].All(x => x == -1))
                        winners.Add(iBoard);
                }

                for (int j = 0; j < 5; j++)
                {
                    var tCount = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (value.Boards[iBoard][i][j] == -1)
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
                        if (value.Boards[winner][i][j] != -1)
                            score += value.Boards[winner][i][j];
                    }
                }

                if (score == 0)
                    throw new Exception("Stupid alert");

                scores.Add(score * call);
                ignoredBoards.Add(winner);
            }

            if (ignoredBoards.Count == value.Boards.Length) break;
        }

        return scores.LastOrDefault();
    }

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
}
