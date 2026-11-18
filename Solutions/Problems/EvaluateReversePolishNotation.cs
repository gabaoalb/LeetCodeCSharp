using Solutions.Models;

namespace Solutions.Problems;

public class EvaluateReversePolishNotation
{
    /// <summary>
    /// Brute force evaluation of Reverse Polish Notation (RPN) expression.
    /// </summary>
    /// <param name="tokens">Array of tokens representing the RPN expression.</param>
    /// <returns>The result of evaluating the RPN expression.</returns>
    public int EvalRPNBruteForce(string[] tokens)
    {
        List<string> tokenList = [.. tokens];

        while (tokenList.Count > 1)
            for (int i = 0; i < tokenList.Count; i++)
                if (tokenList[i] is "+" or "-" or "*" or "/")
                {
                    (int left, int right) = (
                        int.Parse(tokenList[i - 2]),
                        int.Parse(tokenList[i - 1])
                    );

                    int result = tokenList[i] switch
                    {
                        "+" => left + right,
                        "-" => left - right,
                        "*" => left * right,
                        "/" => left / right,
                        _ => throw new InvalidOperationException("Invalid operator"),
                    };

                    tokenList.RemoveRange(i - 2, 3);
                    tokenList.Insert(i - 2, result.ToString());
                    break;
                }

        return int.Parse(tokenList[0]);
    }

    /// <summary>
    /// Evaluation of Reverse Polish Notation (RPN) expression using a doubly linked list.
    /// </summary>
    /// <param name="tokens">Array of tokens representing the RPN expression.</param>
    /// <returns>The result of evaluating the RPN expression.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public int EvalRPNDoublyLinkedList(string[] tokens)
    {
        var current = ListNode<string>.FromArray(tokens);

        while (current is not null)
        {
            if (current.Value is "+" or "-" or "*" or "/")
            {
                var rightNode = current.Prev!;
                var leftNode = rightNode.Prev!;
                var before = leftNode.Prev;

                (int left, int right) = (int.Parse(leftNode.Value!), int.Parse(rightNode.Value!));

                int result = current.Value switch
                {
                    "+" => left + right,
                    "-" => left - right,
                    "*" => left * right,
                    "/" => left / right,
                    _ => throw new InvalidOperationException("Invalid operator"),
                };

                current.Value = result.ToString();
                current.Prev = before;
                before?.Next = current;
            }

            if (current.Next is null)
                break;

            current = current.Next;
        }

        return int.Parse(current!.Value!);
    }

    public int EvalRPNRecursive(string[] tokens)
    {
        int Evaluate(ref int index)
        {
            string token = tokens[index--];
            if (token is "+" or "-" or "*" or "/")
            {
                int right = Evaluate(ref index);
                int left = Evaluate(ref index);
                return token switch
                {
                    "+" => left + right,
                    "-" => left - right,
                    "*" => left * right,
                    "/" => left / right,
                    _ => throw new InvalidOperationException("Invalid operator"),
                };
            }
            return int.Parse(token);
        }

        int i = tokens.Length - 1;
        return Evaluate(ref i);
    }

    /// <summary>
    /// Efficient evaluation of Reverse Polish Notation (RPN) expression using a stack.
    /// </summary>
    /// <param name="tokens">Array of tokens representing the RPN expression.</param>
    /// <returns>The result of evaluating the RPN expression.</returns>
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = [];

        int Apply(Func<int, int, int> operation)
        {
            int right = stack.Pop();
            int left = stack.Pop();
            return operation(left, right);
        }

        foreach (string token in tokens)
        {
            stack.Push(
                token switch
                {
                    "+" => Apply((left, right) => left + right),
                    "-" => Apply((left, right) => left - right),
                    "*" => Apply((left, right) => left * right),
                    "/" => Apply((left, right) => left / right),
                    _ => int.Parse(token),
                }
            );
        }

        return stack.Pop();
    }
}
