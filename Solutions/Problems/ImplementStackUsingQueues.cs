namespace Solutions.Problems;

public class MyStack
{
    #region Constructors
    #endregion

    #region Fields
    private Queue<int> queue1 = new();
    private Queue<int> queue2 = new();
    #endregion

    #region Properties
    #endregion

    #region Events
    #endregion

    #region Methods
    public void Push(int x)
    {
        queue1.Enqueue(x);
    }

    public int Pop()
    {
        while (queue1.Count > 1)
            queue2.Enqueue(queue1.Dequeue());

        int result = queue1.Dequeue();
        (queue2, queue1) = (queue1, queue2);
        return result;
    }

    public int Top()
    {
        while (queue1.Count > 1)
            queue2.Enqueue(queue1.Dequeue());

        int result = queue1.Dequeue();
        queue2.Enqueue(result);
        (queue2, queue1) = (queue1, queue2);
        return result;
    }

    public bool Empty() => queue1.Count == 0;
    #endregion
}
