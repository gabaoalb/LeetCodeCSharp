namespace Solutions.Problems;

public class ValidSudokuSolution
{
    /// <summary>
    /// One-pass solution using hash sets to track seen numbers in rows, columns, and quadrants.
    /// Time complexity: O(n^2) where n is the size of the board (9 in this case).
    /// Space complexity: O(n) for the hash sets used to track seen numbers in rows, columns, and quadrants.
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public bool IsValidSudokuOnePassSlow(char[][] board)
    {
        var (rows, columns, quadrants) = (
            Enumerable.Range(0, 9)
                      .ToDictionary(i => i, _ => new HashSet<char>()),
            Enumerable.Range(0, 9)
                      .ToDictionary(i => i, _ => new HashSet<char>()),
            Enumerable.Range(0, 3)
                      .SelectMany(x => Enumerable.Range(0, 3), (x, y) => (x, y))
                      .ToDictionary(chave => chave, _ => new HashSet<char>())
        );

        for (int x = 0; x < board.Length; x++)
        {
            for (int y = 0; y < board[0].Length; y++)
            {
                if (board[x][y] == '.') continue;

                if (rows[x].Contains(board[x][y]) ||
                    columns[y].Contains(board[x][y]) ||
                    quadrants[(x / 3, y / 3)].Contains(board[x][y]))
                    return false;

                rows[x]?.Add(board[x][y]);
                columns[y]?.Add(board[x][y]);
                quadrants[(x / 3, y / 3)]?.Add(board[x][y]);
            }
        }

        return true;
    }

    public bool IsValidSudokuOnePass(char[][] board)
    {
        var (rows, columns, quadrants) = (new Dictionary<int, HashSet<char>>(),
                                          new Dictionary<int, HashSet<char>>(),
                                          new Dictionary<(int, int), HashSet<char>>());

        for (int x = 0; x < board.Length; x++)
        {
            for (int y = 0; y < board[0].Length; y++)
            {
                if (board[x][y] == '.') continue;

                var quadrantKey = (x / 3, y / 3);

                if ((rows.ContainsKey(x) && rows[x].Contains(board[x][y])) ||
                    (columns.ContainsKey(y) && columns[y].Contains(board[x][y])) ||
                    (quadrants.ContainsKey(quadrantKey) && quadrants[quadrantKey].Contains(board[x][y])))
                    return false;

                if (!rows.ContainsKey(x)) rows[x] = [];
                if (!columns.ContainsKey(y)) columns[y] = [];
                if (!quadrants.ContainsKey(quadrantKey)) quadrants[quadrantKey] = [];

                rows[x]?.Add(board[x][y]);
                columns[y]?.Add(board[x][y]);
                quadrants[quadrantKey]?.Add(board[x][y]);
            }
        }

        return true;
    }

    public bool IsValidSudoku(char[][] board) => IsValidSudokuOnePass(board);
}
