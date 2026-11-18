namespace Solutions.Problems;

public class MinStack
{
    private readonly Stack<int> _stack;
    private readonly Stack<int> _minStack;

    public MinStack()
    {
        _stack = [];
        _minStack = [];
    }

    public void Push(int val)
    {
        _stack.Push(val);
        if (_minStack.Count == 0 || val <= _minStack.Peek())
            _minStack.Push(val);
    }

    public void Pop()
    {
        var popped = _stack.Pop();
        if (_minStack.Count > 0 && popped == _minStack.Peek())
            _minStack.Pop();
    }

    public int Top() => _stack.Peek();

    public int GetMin() => _minStack.Peek();
}
