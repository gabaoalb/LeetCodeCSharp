namespace Solutions;

public class ValidParentheses
{
    /// <summary>
    /// Brute-force solution to check if parentheses are valid
    /// </summary>
    /// <param name="s">Input string containing parentheses</param>
    /// <returns>True if the parentheses are valid, otherwise false</returns>
    public bool IsValidBruteForce(string s)
    {
        while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
            s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");

        return s.Length == 0;
    }

    /// <summary>
    /// Stack-based solution to check if parentheses are valid
    /// </summary>
    /// <param name="s">Input string containing parentheses</param>
    /// <returns>True if the parentheses are valid, otherwise false</returns>
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();

        foreach (char c in s)
        {
            if (c is '(' || c is '[' || c is '{')
                stack.Push(c);
            else
            {
                if (stack.Count == 0)
                    return false;

                char before = stack.Pop();
                if (c is ')' && before != '(')
                    return false;
                if (c is ']' && before != '[')
                    return false;
                if (c is '}' && before != '{')
                    return false;
            }
        }
        return stack.Count == 0;
    }
}
