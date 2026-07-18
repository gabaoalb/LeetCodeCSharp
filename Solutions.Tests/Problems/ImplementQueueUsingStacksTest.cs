using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ImplementQueueUsingStacksTest
{
    [Fact]
    public void Case1()
    {
        var myQueue = new MyQueue();
        myQueue.Push(1);
        myQueue.Push(2);
        Assert.Equal(1, myQueue.Peek());
        Assert.Equal(1, myQueue.Pop());
        Assert.False(myQueue.Empty());
    }

    [Fact]
    public void Case2()
    {
        var myQueue = new MyQueue();
        myQueue.Push(3);
        myQueue.Push(4);
        Assert.Equal(3, myQueue.Peek());
        Assert.Equal(3, myQueue.Pop());
        Assert.False(myQueue.Empty());
    }
}
