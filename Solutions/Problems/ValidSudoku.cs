namespace Solutions.Problems;

public class ValidSudokuSolution
{
    public bool IsValidSudoku(char[][] board)
    {
        var quadrantes = new Dictionary<int, HashSet<char>>();

        for (int x = 0; x < board[0].Length; x++)
        {
            for (int y = 0; x < board.Length; y++)
            {
                if (x <= 2 && y <= 2)
                {
                    //quadrante 1
                    var result = quadrantes.TryGetValue(1, out var currentHashSet);
                    if (!result)
                    {
                        currentHashSet = [];
                        quadrantes[1] = currentHashSet;
                    }

                    if (currentHashSet?.Contains(board[x][y]) ?? false)
                    {
                        return false;
                    }

                    currentHashSet?.Add(board[x][y]);
                }
                else if (x > 2 && x <= 5 && y <= 2)
                {
                    // quadrante 2
                    var result = quadrantes.TryGetValue(2, out var currentHashSet);
                    if (!result)
                    {
                        currentHashSet = [];
                        quadrantes[2] = currentHashSet;
                    }

                    if (currentHashSet?.Contains(board[x][y]) ?? false)
                    {
                        return false;
                    }

                    currentHashSet?.Add(board[x][y]);
                }
                else if (x > 5 && x <= 8 && y <= 2)
                {
                    // quadrante 3
                    var result = quadrantes.TryGetValue(3, out var currentHashSet);
                    if (!result)
                    {
                        currentHashSet = [];
                        quadrantes[3] = currentHashSet;
                    }

                    if (currentHashSet?.Contains(board[x][y]) ?? false)
                    {
                        return false;
                    }

                    currentHashSet?.Add(board[x][y]);
                }
                else if (x <= 2 && y > 2 && y <= 5)
                {
                    // quadrante 4
                    var result = quadrantes.TryGetValue(4, out var currentHashSet);
                    if (!result)
                    {
                        currentHashSet = [];
                        quadrantes[4] = currentHashSet;
                    }

                    if (currentHashSet?.Contains(board[x][y]) ?? false)
                    {
                        return false;
                    }

                    currentHashSet?.Add(board[x][y]);
                }
                else if (x > 2 && x <= 5 && y > 2 && y <= 5)
                {
                    // quadrante 5
                    var result = quadrantes.TryGetValue(5, out var currentHashSet);
                    if (!result)
                    {
                        currentHashSet = [];
                        quadrantes[5] = currentHashSet;
                    }

                    if (currentHashSet?.Contains(board[x][y]) ?? false)
                    {
                        return false;
                    }

                    currentHashSet?.Add(board[x][y]);
                }
                else if (x > 5 && y > 2 && y <= 5)
                {
                    // quadrante 6
                    var result = quadrantes.TryGetValue(6, out var currentHashSet);
                    if (!result)
                    {
                        currentHashSet = [];
                        quadrantes[6] = currentHashSet;
                    }

                    if (currentHashSet?.Contains(board[x][y]) ?? false)
                    {
                        return false;
                    }

                    currentHashSet?.Add(board[x][y]);
                }
                else if (x <= 2 && y > 5)
                {
                    // quadrante 7
                    var result = quadrantes.TryGetValue(7, out var currentHashSet);
                    if (!result)
                    {
                        currentHashSet = [];
                        quadrantes[7] = currentHashSet;
                    }

                    if (currentHashSet?.Contains(board[x][y]) ?? false)
                    {
                        return false;
                    }

                    currentHashSet?.Add(board[x][y]);
                }
                else if (x > 2 && x <= 5 && y > 5)
                {
                    // quadrante 8
                    var result = quadrantes.TryGetValue(8, out var currentHashSet);
                    if (!result)
                    {
                        currentHashSet = [];
                        quadrantes[8] = currentHashSet;
                    }

                    if (currentHashSet?.Contains(board[x][y]) ?? false)
                    {
                        return false;
                    }

                    currentHashSet?.Add(board[x][y]);
                }
                else if (x > 5 && x <= 8 && y > 5)
                {
                    // quadrante 9
                    var result = quadrantes.TryGetValue(9, out var currentHashSet);
                    if (!result)
                    {
                        currentHashSet = [];
                        quadrantes[9] = currentHashSet;
                    }

                    if (currentHashSet?.Contains(board[x][y]) ?? false)
                    {
                        return false;
                    }

                    currentHashSet?.Add(board[x][y]);
                }
            }
        }

        return true;
    }
}
