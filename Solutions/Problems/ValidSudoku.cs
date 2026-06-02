namespace Solutions.Problems;

public class ValidSudokuSolution
{
    /// <summary>
    /// Brute force approach: Check each row, column, and 3x3 square for duplicates.
    /// Time complexity: O(n^2) where n is the size of the board (9 in this case).
    /// Space complexity: O(n) for the hash sets used to track seen numbers in rows, columns, and squares.
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public bool IsValidSudokuBruteForce(char[][] board)
    {
        for (int row = 0; row < board.Length; row++)
        {
            HashSet<char> seen = [];
            for (int i = 0; i < board[row].Length; i++)
            {
                if (board[row][i] == '.') continue;
                if (seen.Contains(board[row][i])) return false;
                seen.Add(board[row][i]);
            }
        }

        for (int col = 0; col < board[0].Length; col++)
        {
            HashSet<char> seen = [];
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][col] == '.') continue;
                if (seen.Contains(board[i][col])) return false;
                seen.Add(board[i][col]);
            }
        }

        for (int square = 0; square < 9; square++)
        {
            HashSet<char> seen = [];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int row = (square / 3) * 3 + i;
                    int col = (square % 3) * 3 + j;
                    if (board[row][col] == '.') continue;
                    if (seen.Contains(board[row][col])) return false;
                    seen.Add(board[row][col]);
                }
            }
        }

        return true;
    }

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

    /// <summary>
    /// One-pass solution using hash sets to track seen numbers in rows, columns, and quadrants.
    /// Time complexity: O(n^2) where n is the size of the board (9 in this case).
    /// Space complexity: O(n) for the hash sets used to track seen numbers in rows
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
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

    /// <summary>
    /// One-pass solution using bitwise operations to track seen numbers in rows, columns, and quadrants.
    /// Time complexity: O(n^2) where n is the size of the board (9 in this case).
    /// Space complexity: O(1) since we are using fixed-size integer arrays to track seen numbers in rows, columns, and quadrants.
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public bool IsValidSudokuBitwise(char[][] board)
    {
        var (rows, columns, quadrants) = (new int[9], new int[9], new int[9]);

        for (int x = 0; x < board.Length; x++)
        {
            for (int y = 0; y < board[0].Length; y++)
            {
                if (board[x][y] == '.') continue;

                int num = board[x][y] - '1';
                int quadrantIndex = x / 3 * 3 + (y / 3);

                if (((rows[x] >> num) & 1) == 1 ||
                    ((columns[y] >> num) & 1) == 1 ||
                    ((quadrants[quadrantIndex] >> num) & 1) == 1)
                    return false;

                rows[x] |= 1 << num;
                columns[y] |= 1 << num;
                quadrants[quadrantIndex] |= 1 << num;
            }
        }

        return true;
    }

    public bool IsValidSudoku(char[][] board) => IsValidSudokuBitwise(board);
}
