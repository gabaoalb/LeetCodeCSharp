namespace Solutions.Problems;

public class MyQueue
{
    #region Constructors
    #endregion

    #region Fields
    private Stack<int> stack1 = new();
    private Stack<int> stack2 = new();
    #endregion

    #region Properties
    #endregion

    #region Events
    #endregion

    #region Methods
    public void Push(int x)
    {
        stack1.Push(x);
    }

    public int Pop()
    {
        while (stack1.Count > 1)
            stack2.Push(stack1.Pop());

        int result = stack1.Pop();
        (stack2, stack1) = (stack1, new Stack<int>(stack2));
        return result;
    }

    public int Peek()
    {
        while (stack1.Count > 1)
            stack2.Push(stack1.Pop());

        int result = stack1.Peek();
        stack2.Push(stack1.Pop());
        (stack2, stack1) = (stack1, new Stack<int>(stack2));
        return result;
    }

    public bool Empty() => stack1.Count == 0;
    #endregion
}
