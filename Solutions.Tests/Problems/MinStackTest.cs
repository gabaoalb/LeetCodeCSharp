using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class MinStackTest
{
    [Fact]
    public void Case1_ProblemExample()
    {
        var stack = new MinStack();
        stack.Push(-2);
        stack.Push(0);
        stack.Push(-3);

        Assert.Equal(-3, stack.GetMin());
        stack.Pop();
        Assert.Equal(0, stack.Top());
        Assert.Equal(-2, stack.GetMin());
    }

    [Fact]
    public void Case2_SingleElement()
    {
        var stack = new MinStack();
        stack.Push(5);

        Assert.Equal(5, stack.Top());
        Assert.Equal(5, stack.GetMin());
        Assert.Equal(5, stack.Top());
        Assert.Equal(5, stack.GetMin());
    }

    [Fact]
    public void Case3_IncreasingValues()
    {
        var stack = new MinStack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Top());
        Assert.Equal(1, stack.GetMin());
        stack.Pop();
        Assert.Equal(2, stack.Top());
        Assert.Equal(1, stack.GetMin());
        stack.Pop();
        Assert.Equal(1, stack.Top());
        Assert.Equal(1, stack.GetMin());
    }

    [Fact]
    public void Case4_DecreasingValues()
    {
        var stack = new MinStack();
        stack.Push(3);
        stack.Push(2);
        stack.Push(1);

        Assert.Equal(1, stack.GetMin());
        stack.Pop();
        Assert.Equal(2, stack.Top());
        Assert.Equal(2, stack.GetMin());
        stack.Pop();
        Assert.Equal(3, stack.Top());
        Assert.Equal(3, stack.GetMin());
    }

    [Fact]
    public void Case5_DuplicateMinimum()
    {
        var stack = new MinStack();
        stack.Push(2);
        stack.Push(1);
        stack.Push(1);

        Assert.Equal(1, stack.GetMin());
        stack.Pop();
        Assert.Equal(1, stack.Top());
        Assert.Equal(1, stack.GetMin());
        stack.Pop();
        Assert.Equal(2, stack.GetMin());
    }

    [Fact]
    public void Case6_IntegerLimits()
    {
        var stack = new MinStack();
        stack.Push(int.MaxValue);
        stack.Push(int.MinValue);

        Assert.Equal(int.MinValue, stack.Top());
        Assert.Equal(int.MinValue, stack.GetMin());
        stack.Pop();
        Assert.Equal(int.MaxValue, stack.Top());
        Assert.Equal(int.MaxValue, stack.GetMin());
    }

    [Fact]
    public void Case7_ReuseAfterEmptying()
    {
        var stack = new MinStack();
        stack.Push(-5);
        stack.Pop();
        stack.Push(10);

        Assert.Equal(10, stack.Top());
        Assert.Equal(10, stack.GetMin());
        stack.Push(4);
        Assert.Equal(4, stack.Top());
        Assert.Equal(4, stack.GetMin());
    }
}
