namespace Solutions.Problems;

public class ValidParenthesesSolution
{
    public bool IsValidBruteForce(string s)
    {
        while (s.Contains("()") || s.Contains("{}") || s.Contains("[]"))
            s = s.Replace("()", "")
                 .Replace("{}", "")
                 .Replace("[]", "");

        return s.Length == 0;
    }

    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (c == '(' || c == '{' || c == '[')
                stack.Push(c);
            else
            {
                if (stack.Count == 0)
                    return false;
                var top = stack.Pop();
                if (c == ')' && top != '(')
                    return false;
                if (c == '}' && top != '{')
                    return false;
                if (c == ']' && top != '[')
                    return false;
            }
        }
        return stack.Count == 0;
    }
}
